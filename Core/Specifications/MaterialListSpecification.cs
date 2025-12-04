using System;
using System.Security.Cryptography.X509Certificates;
using Core.Entities;

namespace Core.Specifications;

public class MaterialListSpecification : BaseSpecification<Parts, string>
{
    public MaterialListSpecification()
    {
        AddSelect(x => x.Material );
        ApplyDistinct();
    }
}
