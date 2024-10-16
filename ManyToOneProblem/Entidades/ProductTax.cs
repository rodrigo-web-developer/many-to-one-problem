using System;
using System.Collections.Generic;
using System.Text;

namespace ManyToOneProblem.Entidades
{
public class ProductTax
{
    public long Id { get; set; }
    public double Tax1 { get; set; }
    public double Tax2 { get; set; }
    public double Tax3 { get; set; }
    public Product Product { get; set; }
}
}
