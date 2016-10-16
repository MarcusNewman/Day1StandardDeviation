using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReflectionUnitTesting;
using System.Reflection;

[TestClass]
public class SolutionUnitTests
{
    [TestMethod]
    public void AssemblyShouldExist()
    {
        GetAssembly();
    }

    static Assembly GetAssembly()
    {
        return ReflectionAssert.AssemblyExists("Day1StandardDeviation.exe");
    }

    [TestMethod]
    public void ClassShouldExist()
    {
        GetClass();
    }

    static Type GetClass()
    {
        return GetAssembly().TypeExists("Solution");
    }

    [TestMethod]
    public void MethodShouldExist()
    {
        GetMethod();
    }

    static MethodInfo GetMethod()
    {
        return GetClass().MethodExists(
            methodName: "StandardDeviation",
            shouldBeStatic: true,
            shouldReturnType: typeof(string),
            parameterTypesAndNames: new System.Collections.Generic.List<Tuple<Type, string>> {
                Tuple.Create(typeof(int[]), "values") });
    }

    [TestMethod]
    public void StandardDeviationOf1ShouldBe0()
    {
        var parameters = new object[] { new int[] { 1 } };
        var expectedResult = "0.0";
        GetMethod().TestMethod(null, parameters, expectedResult);

    }

    //5
    //10 40 30 50 20
    //14.1
    [TestMethod]
    public void StandardDeviationOf1040305020ShouldBe141()
    {
        var parameters = new object[] { new int[] { 10,40,30,50,20 } };
        var expectedResult = "14.1";
        GetMethod().TestMethod(null, parameters, expectedResult);

    }
}

