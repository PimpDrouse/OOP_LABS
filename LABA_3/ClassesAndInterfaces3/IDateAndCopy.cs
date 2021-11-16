using System;

namespace LABA_3.ClassesAndInterfaces
{
    internal interface IDateAndCopy
    {
        object DeepCopy();
        DateTime DateOfCreation { get; set; }
    }
}