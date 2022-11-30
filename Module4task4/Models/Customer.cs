using System.Collections.Generic;

namespace Module4task4.Models;

public class Customer
{
    public int Id { get; set; }
    public string Fullname { get; set; }
    public List<Orders> Orders { get; set; }
}