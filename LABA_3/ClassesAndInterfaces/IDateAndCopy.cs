using System;

namespace LABA_2.ClassesAndInterfaces
{
    internal interface IDateAndCopy
    {
        object DeepCopy();
        DateTime DateOfCreation { get; set; }
    }
}