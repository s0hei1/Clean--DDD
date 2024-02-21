using Domain;
using NetArchTest.Rules;
using Xunit;

namespace Architecture.Test;

public class ArchitectureTests
{
    private const string DomainNameSpace = "Domain";
    private const string ApplicationNameSpace = "Application";
    private const string PresentationNameSpace = "Presentation";
    private const string InfrastructureNameSpace = "Infrastructure";
    private const string WebNameSpace = "Web";

    [Fact]
    public void Domain_Should_Not_Have_Dependency_On_Other_Projects()
    {
        // Arrange
        var assembly = typeof(Domain.AssemblyReference).Assembly;


        var objectProjects = new[]
        {
            ApplicationNameSpace,
            InfrastructureNameSpace,
            PresentationNameSpace,
            WebNameSpace
        };
        
        // Act
        var testResult = Types
                .InAssembly(assembly)
                .ShouldNot()
                .HaveDependencyOnAll(objectProjects)
                .GetResult();

        // Assert
        Assert.True(testResult.IsSuccessful);

    }
}