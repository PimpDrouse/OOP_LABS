using System;

namespace LABA_4.ClassesAndInterfaces
{
    internal interface IDateAndCopy
    {
        object DeepCopy();
        DateTime DateOfCreation { get; set; }
    }
}