using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace XribaInterviews.DataDbChallenge.Models;

public partial class NorthwindContext : DbContext
{
    public NorthwindContext()
    {
    }

    public NorthwindContext(DbContextOptions<NorthwindContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AlphabeticalListOfProduct> AlphabeticalListOfProducts { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<CategorySalesFor1997> CategorySalesFor1997s { get; set; }

    public virtual DbSet<CurrentProductList> CurrentProductLists { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<CustomerAndSuppliersByCity> CustomerAndSuppliersByCities { get; set; }

    public virtual DbSet<CustomerDemographic> CustomerDemographics { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<EmployeeTerritory> EmployeeTerritories { get; set; }

    public virtual DbSet<Invoice> Invoices { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderDetail> OrderDetails { get; set; }

    public virtual DbSet<OrderDetailsExtended> OrderDetailsExtendeds { get; set; }

    public virtual DbSet<OrderSubtotal> OrderSubtotals { get; set; }

    public virtual DbSet<OrdersQry> OrdersQries { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductSalesFor1997> ProductSalesFor1997s { get; set; }

    public virtual DbSet<ProductsAboveAveragePrice> ProductsAboveAveragePrices { get; set; }

    public virtual DbSet<ProductsByCategory> ProductsByCategories { get; set; }

    public virtual DbSet<QuarterlyOrder> QuarterlyOrders { get; set; }

    public virtual DbSet<Region> Regions { get; set; }

    public virtual DbSet<SalesByCategory> SalesByCategories { get; set; }

    public virtual DbSet<SalesTotalsByAmount> SalesTotalsByAmounts { get; set; }

    public virtual DbSet<Shipper> Shippers { get; set; }

    public virtual DbSet<SummaryOfSalesByQuarter> SummaryOfSalesByQuarters { get; set; }

    public virtual DbSet<SummaryOfSalesByYear> SummaryOfSalesByYears { get; set; }

    public virtual DbSet<Supplier> Suppliers { get; set; }

    public virtual DbSet<Territory> Territories { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlite("Data Source=.\\DataDbChallenge\\northwind.db");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AlphabeticalListOfProduct>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("Alphabetical list of products");

            entity.Property(e => e.CategoryId)
                .HasColumnType("INT")
                .HasColumnName("CategoryID");
            entity.Property(e => e.CategoryName).HasColumnType("NVARCHAR(15)");
            entity.Property(e => e.Discontinued).HasColumnType("BOOLEAN");
            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.ProductName).HasColumnType("NVARCHAR(40)");
            entity.Property(e => e.QuantityPerUnit).HasColumnType("NVARCHAR(20)");
            entity.Property(e => e.ReorderLevel).HasColumnType("SMALLINT");
            entity.Property(e => e.SupplierId)
                .HasColumnType("INT")
                .HasColumnName("SupplierID");
            entity.Property(e => e.UnitPrice).HasColumnType("FLOAT(19,4)");
            entity.Property(e => e.UnitsInStock).HasColumnType("SMALLINT");
            entity.Property(e => e.UnitsOnOrder).HasColumnType("SMALLINT");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.CategoryName).HasColumnType("NVARCHAR(15)");
        });

        modelBuilder.Entity<CategorySalesFor1997>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("Category Sales for 1997");

            entity.Property(e => e.CategoryName).HasColumnType("NVARCHAR(15)");
        });

        modelBuilder.Entity<CurrentProductList>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("Current Product List");

            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.ProductName).HasColumnType("NVARCHAR(40)");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.Property(e => e.CustomerId)
                .HasColumnType("CHAR(5)")
                .HasColumnName("CustomerID");
            entity.Property(e => e.Address).HasColumnType("NVARCHAR(60)");
            entity.Property(e => e.City).HasColumnType("NVARCHAR(15)");
            entity.Property(e => e.CompanyName).HasColumnType("NVARCHAR(40)");
            entity.Property(e => e.ContactName).HasColumnType("NVARCHAR(30)");
            entity.Property(e => e.ContactTitle).HasColumnType("NVARCHAR(30)");
            entity.Property(e => e.Country).HasColumnType("NVARCHAR(15)");
            entity.Property(e => e.Fax).HasColumnType("NVARCHAR(24)");
            entity.Property(e => e.Phone).HasColumnType("NVARCHAR(24)");
            entity.Property(e => e.PostalCode).HasColumnType("NVARCHAR(10)");
            entity.Property(e => e.Region).HasColumnType("NVARCHAR(15)");

            entity.HasMany(d => d.CustomerTypes).WithMany(p => p.Customers)
                .UsingEntity<Dictionary<string, object>>(
                    "CustomerCustomerDemo",
                    r => r.HasOne<CustomerDemographic>().WithMany()
                        .HasForeignKey("CustomerTypeId")
                        .OnDelete(DeleteBehavior.ClientSetNull),
                    l => l.HasOne<Customer>().WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.ClientSetNull),
                    j =>
                    {
                        j.HasKey("CustomerId", "CustomerTypeId");
                        j.ToTable("CustomerCustomerDemo");
                        j.IndexerProperty<string>("CustomerId")
                            .HasColumnType("CHAR(5)")
                            .HasColumnName("CustomerID");
                        j.IndexerProperty<string>("CustomerTypeId")
                            .HasColumnType("CHAR(10)")
                            .HasColumnName("CustomerTypeID");
                    });
        });

        modelBuilder.Entity<CustomerAndSuppliersByCity>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("Customer and Suppliers by City");

            entity.Property(e => e.City).HasColumnType("NVARCHAR(15)");
            entity.Property(e => e.CompanyName).HasColumnType("NVARCHAR(40)");
            entity.Property(e => e.ContactName).HasColumnType("NVARCHAR(30)");
        });

        modelBuilder.Entity<CustomerDemographic>(entity =>
        {
            entity.HasKey(e => e.CustomerTypeId);

            entity.Property(e => e.CustomerTypeId)
                .HasColumnType("CHAR(10)")
                .HasColumnName("CustomerTypeID");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");
            entity.Property(e => e.Address).HasColumnType("NVARCHAR(60)");
            entity.Property(e => e.BirthDate).HasColumnType("DATETIME");
            entity.Property(e => e.City).HasColumnType("NVARCHAR(15)");
            entity.Property(e => e.Country).HasColumnType("NVARCHAR(15)");
            entity.Property(e => e.Extension).HasColumnType("NVARCHAR(4)");
            entity.Property(e => e.FirstName).HasColumnType("NVARCHAR(10)");
            entity.Property(e => e.HireDate).HasColumnType("DATETIME");
            entity.Property(e => e.HomePhone).HasColumnType("NVARCHAR(24)");
            entity.Property(e => e.LastName).HasColumnType("NVARCHAR(20)");
            entity.Property(e => e.PhotoPath).HasColumnType("NVARCHAR(255)");
            entity.Property(e => e.PostalCode).HasColumnType("NVARCHAR(10)");
            entity.Property(e => e.Region).HasColumnType("NVARCHAR(15)");
            entity.Property(e => e.ReportsTo).HasColumnType("INT");
            entity.Property(e => e.Title).HasColumnType("NVARCHAR(30)");
            entity.Property(e => e.TitleOfCourtesy).HasColumnType("NVARCHAR(25)");

            entity.HasOne(d => d.ReportsToNavigation).WithMany(p => p.InverseReportsToNavigation).HasForeignKey(d => d.ReportsTo);
        });

        modelBuilder.Entity<EmployeeTerritory>(entity =>
        {
            entity.Property(e => e.EmployeeTerritoryId).HasColumnName("EmployeeTerritoryID");
            entity.Property(e => e.EmployeeId)
                .HasColumnType("INT")
                .HasColumnName("EmployeeID");
            entity.Property(e => e.TerritoryId)
                .HasColumnType("NVARCHAR ( 20 )")
                .HasColumnName("TerritoryID");

            entity.HasOne(d => d.Employee).WithMany(p => p.EmployeeTerritories)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Territory).WithMany(p => p.EmployeeTerritories)
                .HasForeignKey(d => d.TerritoryId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Invoice>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("Invoices");

            entity.Property(e => e.Address1)
                .HasColumnType("NVARCHAR(60)")
                .HasColumnName("Address:1");
            entity.Property(e => e.City1)
                .HasColumnType("NVARCHAR(15)")
                .HasColumnName("City:1");
            entity.Property(e => e.Country1)
                .HasColumnType("NVARCHAR(15)")
                .HasColumnName("Country:1");
            entity.Property(e => e.CustomerId1)
                .HasColumnType("CHAR(5)")
                .HasColumnName("CustomerID:1");
            entity.Property(e => e.CustomerName).HasColumnType("NVARCHAR(40)");
            entity.Property(e => e.Discount).HasColumnType("REAL ( 24 , 0 )");
            entity.Property(e => e.Freight).HasColumnType("FLOAT(19,4)");
            entity.Property(e => e.OrderDate).HasColumnType("DATETIME");
            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.PostalCode1)
                .HasColumnType("NVARCHAR(10)")
                .HasColumnName("PostalCode:1");
            entity.Property(e => e.ProductId1)
                .HasColumnType("INT")
                .HasColumnName("ProductID:1");
            entity.Property(e => e.ProductName).HasColumnType("NVARCHAR(40)");
            entity.Property(e => e.Quantity).HasColumnType("SMALLINT");
            entity.Property(e => e.Region1)
                .HasColumnType("NVARCHAR(15)")
                .HasColumnName("Region:1");
            entity.Property(e => e.RequiredDate).HasColumnType("DATETIME");
            entity.Property(e => e.ShipAddress).HasColumnType("NVARCHAR(60)");
            entity.Property(e => e.ShipCity).HasColumnType("NVARCHAR(15)");
            entity.Property(e => e.ShipCountry).HasColumnType("NVARCHAR(15)");
            entity.Property(e => e.ShipName).HasColumnType("NVARCHAR(40)");
            entity.Property(e => e.ShipPostalCode).HasColumnType("NVARCHAR(10)");
            entity.Property(e => e.ShipRegion).HasColumnType("NVARCHAR(15)");
            entity.Property(e => e.ShippedDate).HasColumnType("DATETIME");
            entity.Property(e => e.ShipperName).HasColumnType("NVARCHAR(40)");
            entity.Property(e => e.UnitPrice1)
                .HasColumnType("FLOAT ( 19 , 4 )")
                .HasColumnName("UnitPrice:1");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.CustomerId)
                .HasColumnType("CHAR(5)")
                .HasColumnName("CustomerID");
            entity.Property(e => e.EmployeeId)
                .HasColumnType("INT")
                .HasColumnName("EmployeeID");
            entity.Property(e => e.Freight)
                .HasDefaultValueSql("0")
                .HasColumnType("FLOAT(19,4)");
            entity.Property(e => e.OrderDate).HasColumnType("DATETIME");
            entity.Property(e => e.RequiredDate).HasColumnType("DATETIME");
            entity.Property(e => e.ShipAddress).HasColumnType("NVARCHAR(60)");
            entity.Property(e => e.ShipCity).HasColumnType("NVARCHAR(15)");
            entity.Property(e => e.ShipCountry).HasColumnType("NVARCHAR(15)");
            entity.Property(e => e.ShipName).HasColumnType("NVARCHAR(40)");
            entity.Property(e => e.ShipPostalCode).HasColumnType("NVARCHAR(10)");
            entity.Property(e => e.ShipRegion).HasColumnType("NVARCHAR(15)");
            entity.Property(e => e.ShipVia).HasColumnType("INT");
            entity.Property(e => e.ShippedDate).HasColumnType("DATETIME");

            entity.HasOne(d => d.Customer).WithMany(p => p.Orders).HasForeignKey(d => d.CustomerId);

            entity.HasOne(d => d.Employee).WithMany(p => p.Orders).HasForeignKey(d => d.EmployeeId);

            entity.HasOne(d => d.ShipViaNavigation).WithMany(p => p.Orders).HasForeignKey(d => d.ShipVia);
        });

        modelBuilder.Entity<OrderDetail>(entity =>
        {
            entity.Property(e => e.OrderDetailId).HasColumnName("OrderDetailID");
            entity.Property(e => e.Discount).HasColumnType("REAL ( 24 , 0 )");
            entity.Property(e => e.OrderId)
                .HasColumnType("INT")
                .HasColumnName("OrderID");
            entity.Property(e => e.ProductId)
                .HasColumnType("INT")
                .HasColumnName("ProductID");
            entity.Property(e => e.Quantity)
                .HasDefaultValueSql("1")
                .HasColumnType("SMALLINT");
            entity.Property(e => e.UnitPrice).HasColumnType("FLOAT ( 19 , 4 )");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Product).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<OrderDetailsExtended>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("OrderDetails Extended");

            entity.Property(e => e.Discount).HasColumnType("REAL ( 24 , 0 )");
            entity.Property(e => e.OrderId)
                .HasColumnType("INT")
                .HasColumnName("OrderID");
            entity.Property(e => e.ProductId)
                .HasColumnType("INT")
                .HasColumnName("ProductID");
            entity.Property(e => e.ProductName).HasColumnType("NVARCHAR(40)");
            entity.Property(e => e.Quantity).HasColumnType("SMALLINT");
            entity.Property(e => e.UnitPrice).HasColumnType("FLOAT ( 19 , 4 )");
        });

        modelBuilder.Entity<OrderSubtotal>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("Order Subtotals");

            entity.Property(e => e.OrderId)
                .HasColumnType("INT")
                .HasColumnName("OrderID");
        });

        modelBuilder.Entity<OrdersQry>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("Orders Qry");

            entity.Property(e => e.Address).HasColumnType("NVARCHAR(60)");
            entity.Property(e => e.City).HasColumnType("NVARCHAR(15)");
            entity.Property(e => e.CompanyName).HasColumnType("NVARCHAR(40)");
            entity.Property(e => e.Country).HasColumnType("NVARCHAR(15)");
            entity.Property(e => e.CustomerId)
                .HasColumnType("CHAR(5)")
                .HasColumnName("CustomerID");
            entity.Property(e => e.EmployeeId)
                .HasColumnType("INT")
                .HasColumnName("EmployeeID");
            entity.Property(e => e.Freight).HasColumnType("FLOAT(19,4)");
            entity.Property(e => e.OrderDate).HasColumnType("DATETIME");
            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.PostalCode).HasColumnType("NVARCHAR(10)");
            entity.Property(e => e.Region).HasColumnType("NVARCHAR(15)");
            entity.Property(e => e.RequiredDate).HasColumnType("DATETIME");
            entity.Property(e => e.ShipAddress).HasColumnType("NVARCHAR(60)");
            entity.Property(e => e.ShipCity).HasColumnType("NVARCHAR(15)");
            entity.Property(e => e.ShipCountry).HasColumnType("NVARCHAR(15)");
            entity.Property(e => e.ShipName).HasColumnType("NVARCHAR(40)");
            entity.Property(e => e.ShipPostalCode).HasColumnType("NVARCHAR(10)");
            entity.Property(e => e.ShipRegion).HasColumnType("NVARCHAR(15)");
            entity.Property(e => e.ShipVia).HasColumnType("INT");
            entity.Property(e => e.ShippedDate).HasColumnType("DATETIME");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.CategoryId)
                .HasColumnType("INT")
                .HasColumnName("CategoryID");
            entity.Property(e => e.Discontinued)
                .HasDefaultValueSql("0")
                .HasColumnType("BOOLEAN");
            entity.Property(e => e.ProductName).HasColumnType("NVARCHAR(40)");
            entity.Property(e => e.QuantityPerUnit).HasColumnType("NVARCHAR(20)");
            entity.Property(e => e.ReorderLevel)
                .HasDefaultValueSql("0")
                .HasColumnType("SMALLINT");
            entity.Property(e => e.SupplierId)
                .HasColumnType("INT")
                .HasColumnName("SupplierID");
            entity.Property(e => e.UnitPrice)
                .HasDefaultValueSql("0")
                .HasColumnType("FLOAT(19,4)");
            entity.Property(e => e.UnitsInStock)
                .HasDefaultValueSql("0")
                .HasColumnType("SMALLINT");
            entity.Property(e => e.UnitsOnOrder)
                .HasDefaultValueSql("0")
                .HasColumnType("SMALLINT");

            entity.HasOne(d => d.Category).WithMany(p => p.Products).HasForeignKey(d => d.CategoryId);

            entity.HasOne(d => d.Supplier).WithMany(p => p.Products).HasForeignKey(d => d.SupplierId);
        });

        modelBuilder.Entity<ProductSalesFor1997>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("Product Sales for 1997");

            entity.Property(e => e.CategoryName).HasColumnType("NVARCHAR(15)");
            entity.Property(e => e.ProductName).HasColumnType("NVARCHAR(40)");
        });

        modelBuilder.Entity<ProductsAboveAveragePrice>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("Products Above Average Price");

            entity.Property(e => e.ProductName).HasColumnType("NVARCHAR(40)");
            entity.Property(e => e.UnitPrice).HasColumnType("FLOAT(19,4)");
        });

        modelBuilder.Entity<ProductsByCategory>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("Products by Category");

            entity.Property(e => e.CategoryName).HasColumnType("NVARCHAR(15)");
            entity.Property(e => e.Discontinued).HasColumnType("BOOLEAN");
            entity.Property(e => e.ProductName).HasColumnType("NVARCHAR(40)");
            entity.Property(e => e.QuantityPerUnit).HasColumnType("NVARCHAR(20)");
            entity.Property(e => e.UnitsInStock).HasColumnType("SMALLINT");
        });

        modelBuilder.Entity<QuarterlyOrder>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("Quarterly Orders");

            entity.Property(e => e.City).HasColumnType("NVARCHAR(15)");
            entity.Property(e => e.CompanyName).HasColumnType("NVARCHAR(40)");
            entity.Property(e => e.Country).HasColumnType("NVARCHAR(15)");
            entity.Property(e => e.CustomerId)
                .HasColumnType("CHAR(5)")
                .HasColumnName("CustomerID");
        });

        modelBuilder.Entity<Region>(entity =>
        {
            entity.ToTable("Region");

            entity.Property(e => e.RegionId)
                .ValueGeneratedNever()
                .HasColumnType("INT")
                .HasColumnName("RegionID");
            entity.Property(e => e.RegionDescription).HasColumnType("CHAR(50)");
        });

        modelBuilder.Entity<SalesByCategory>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("Sales by Category");

            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.CategoryName).HasColumnType("NVARCHAR(15)");
            entity.Property(e => e.ProductName).HasColumnType("NVARCHAR(40)");
        });

        modelBuilder.Entity<SalesTotalsByAmount>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("Sales Totals by Amount");

            entity.Property(e => e.CompanyName).HasColumnType("NVARCHAR(40)");
            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.ShippedDate).HasColumnType("DATETIME");
        });

        modelBuilder.Entity<Shipper>(entity =>
        {
            entity.Property(e => e.ShipperId).HasColumnName("ShipperID");
            entity.Property(e => e.CompanyName).HasColumnType("NVARCHAR(40)");
            entity.Property(e => e.Phone).HasColumnType("NVARCHAR(24)");
        });

        modelBuilder.Entity<SummaryOfSalesByQuarter>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("Summary of Sales by Quarter");

            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.ShippedDate).HasColumnType("DATETIME");
        });

        modelBuilder.Entity<SummaryOfSalesByYear>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("Summary of Sales by Year");

            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.ShippedDate).HasColumnType("DATETIME");
        });

        modelBuilder.Entity<Supplier>(entity =>
        {
            entity.Property(e => e.SupplierId).HasColumnName("SupplierID");
            entity.Property(e => e.Address).HasColumnType("NVARCHAR(60)");
            entity.Property(e => e.City).HasColumnType("NVARCHAR(15)");
            entity.Property(e => e.CompanyName).HasColumnType("NVARCHAR(40)");
            entity.Property(e => e.ContactName).HasColumnType("NVARCHAR(30)");
            entity.Property(e => e.ContactTitle).HasColumnType("NVARCHAR(30)");
            entity.Property(e => e.Country).HasColumnType("NVARCHAR(15)");
            entity.Property(e => e.Fax).HasColumnType("NVARCHAR(24)");
            entity.Property(e => e.Phone).HasColumnType("NVARCHAR(24)");
            entity.Property(e => e.PostalCode).HasColumnType("NVARCHAR(10)");
            entity.Property(e => e.Region).HasColumnType("NVARCHAR(15)");
        });

        modelBuilder.Entity<Territory>(entity =>
        {
            entity.Property(e => e.TerritoryId)
                .HasColumnType("NVARCHAR(20)")
                .HasColumnName("TerritoryID");
            entity.Property(e => e.RegionId)
                .HasColumnType("INT")
                .HasColumnName("RegionID");
            entity.Property(e => e.TerritoryDescription).HasColumnType("CHAR(50)");

            entity.HasOne(d => d.Region).WithMany(p => p.Territories)
                .HasForeignKey(d => d.RegionId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
