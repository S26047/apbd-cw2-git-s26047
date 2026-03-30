using System;
using System.Collections.Generic;
using System.Linq;

public class RentalServices
{
    private List<Equipment> _equipments = new();
    private List<User> _users = new();
    private List<Loan> _loans = new();

    private int _equipmentId = 1;
    private int _userId = 1;
    private int _loanId = 1;


    public void AddEquipment(Equipment equipment)
    {
        equipment.Id = _equipmentId++;
        _equipments.Add(equipment);
    }

    public void AddUser(User user)
    {
        user.Id = _userID++;
        _users.Add(user);
    }

    public List<Equipment> GetAllEquipment()
    {
        return _equipments;
    }
    
    public List<Equipment> GetAvailableEquipment()
    {
        return _equipments.Where(e => e.IsAvailable).ToList();
    }

    public void RentEquipment(int userId, int equipmentId, int days)
    {
        var user = _users.FirstOrDefault(u => u.Id == userId);
        var equipment = _equipments.FirstOrDefault(e => e.Id == equipmentId);
        
        if (user == null)
            throw new Exception("User not found");
        
        if (equipment == null)
            throw new Exception("Equipment not found");
        
        if (!equipment.IsAvailable)
            throw new Exception("Equipment is not available");
        
        var activeLoans = _loans.Count(l => l.User.Id == userId && l.ReturnDate == null);

        if (activeLoans >= user.MaxLoans)
            throw new Exception("User exceeded loan limit");

        var loan = new Loan
        {
            Id = _loanId++,
            User = user,
            Equipment = equipment,
            LoanDate = DateTime.now,
            DueDate = DateTime.now.AddDays(days)
        };

        equipment.IsAvailable = false;
        _loans.Add(loan);
    }

    public void ReturnEquipment(int loanId)
    {
        var loan = _loans.FirstOrDefault(l => l.Id == loanId);
        
        if (loan == null)
            throw new Exception("Loan not found");
        
        if (loan.ReturnDate != null)
            throw new Exception("Already returned");

        loan.ReturnDate = DateTime.Now;
        loan.Equipment.IsAvailable = true;

        if (loan.ReturnDate > loan.DueDate)
        {
            var daysLate = (loan.ReturnDate.Value - loan.DueDate).Days;
            loan.Penalty = daysLate * 10;
        }
    }

    public List<Loan> GetUserActiveLoans(int userId)
    {
        return _loans
            .Where(l => l.User.Id == userId && l.ReturnDate == null)
            .ToList();
    }

    public List<Loan> GetOvedueLoans()
    {
        return _loans
            .Where(l => l.ReturnDate == null && l.DueDate < DateTime.Now)
            .ToList();
    }
}