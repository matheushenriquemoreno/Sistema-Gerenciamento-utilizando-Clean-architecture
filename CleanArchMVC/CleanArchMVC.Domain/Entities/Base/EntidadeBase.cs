using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchMVC.Domain.Interfaces.Base;

namespace CleanArchMVC.Domain.Entities.Base;
public class EntidadeBase : IEntidadeBase
{
    public int Id { get; protected set; }
}

