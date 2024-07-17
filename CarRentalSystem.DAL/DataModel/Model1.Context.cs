﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CarRentalSystem.DAL.DataModel
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class CarRentalEntities : DbContext
    {
        public CarRentalEntities()
            : base("name=CarRentalEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<tbl_CarRegistration> tbl_CarRegistration { get; set; }
        public virtual DbSet<tbl_UserRegistration> tbl_UserRegistration { get; set; }
        public virtual DbSet<tbl_Countries> tbl_Countries { get; set; }
        public virtual DbSet<tbl_States> tbl_States { get; set; }
        public virtual DbSet<tbl_Login> tbl_Login { get; set; }
    
        public virtual ObjectResult<sp_select_Result> sp_select(Nullable<int> userID)
        {
            var userIDParameter = userID.HasValue ?
                new ObjectParameter("UserID", userID) :
                new ObjectParameter("UserID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_select_Result>("sp_select", userIDParameter);
        }
    
        public virtual int sp_update(Nullable<int> userID, string firstName, string lastName, string email, string country, string state, string carRented)
        {
            var userIDParameter = userID.HasValue ?
                new ObjectParameter("UserID", userID) :
                new ObjectParameter("UserID", typeof(int));
    
            var firstNameParameter = firstName != null ?
                new ObjectParameter("FirstName", firstName) :
                new ObjectParameter("FirstName", typeof(string));
    
            var lastNameParameter = lastName != null ?
                new ObjectParameter("LastName", lastName) :
                new ObjectParameter("LastName", typeof(string));
    
            var emailParameter = email != null ?
                new ObjectParameter("Email", email) :
                new ObjectParameter("Email", typeof(string));
    
            var countryParameter = country != null ?
                new ObjectParameter("Country", country) :
                new ObjectParameter("Country", typeof(string));
    
            var stateParameter = state != null ?
                new ObjectParameter("State", state) :
                new ObjectParameter("State", typeof(string));
    
            var carRentedParameter = carRented != null ?
                new ObjectParameter("CarRented", carRented) :
                new ObjectParameter("CarRented", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_update", userIDParameter, firstNameParameter, lastNameParameter, emailParameter, countryParameter, stateParameter, carRentedParameter);
        }
    
        public virtual int sp_carupdate(Nullable<int> carID, string carName, string carMileage, Nullable<int> quantity)
        {
            var carIDParameter = carID.HasValue ?
                new ObjectParameter("CarID", carID) :
                new ObjectParameter("CarID", typeof(int));
    
            var carNameParameter = carName != null ?
                new ObjectParameter("CarName", carName) :
                new ObjectParameter("CarName", typeof(string));
    
            var carMileageParameter = carMileage != null ?
                new ObjectParameter("CarMileage", carMileage) :
                new ObjectParameter("CarMileage", typeof(string));
    
            var quantityParameter = quantity.HasValue ?
                new ObjectParameter("Quantity", quantity) :
                new ObjectParameter("Quantity", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_carupdate", carIDParameter, carNameParameter, carMileageParameter, quantityParameter);
        }
    
        public virtual int QuantityCheck(string carName, Nullable<int> operation)
        {
            var carNameParameter = carName != null ?
                new ObjectParameter("CarName", carName) :
                new ObjectParameter("CarName", typeof(string));
    
            var operationParameter = operation.HasValue ?
                new ObjectParameter("Operation", operation) :
                new ObjectParameter("Operation", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("QuantityCheck", carNameParameter, operationParameter);
        }
    }
}