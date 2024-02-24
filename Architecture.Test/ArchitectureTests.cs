using System;
using Domain;
using Application;
using Infrastructure;
using NetArchTest.Rules;
using Web;
using Presentation;
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
    
    [Fact]
    public void Application_Should_Not_Have_Dependency_On_Other_Projects()
    {
        // Arrange
        var assembly = typeof(Application.AssemblyReference).Assembly;

        var objectProjects = new[]
        {
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
    
    [Fact]
    public void Handlers_Should_Have_Dependency_On_Domain()
    {
        // Arrange
        var assembly = typeof(Application.AssemblyReference).Assembly;

        // Act
        var result =
            Types
                .InAssembly(assembly)
                .That()
                .HaveNameEndingWith("Handler")
                .Should()
                .HaveDependencyOn(DomainNameSpace)
                .GetResult();

        // Assert
        Assert.True(result.IsSuccessful);

    }

    
    
    [Fact]
    public void Infrastructure_Should_Not_Have_Dependency_On_Other_Projects()
    {
        // Arrange
        var assembly = typeof(Infrastructure.AssemblyReference).Assembly;

        var objectProjects = new[]
        {
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
    
        
    [Fact]
    public void Presentation_Should_Not_Have_Dependency_On_Other_Projects()
    {
        // Arrange
        var assembly = typeof(Presentation.AssemblyReference).Assembly;

        var objectProjects = new[]
        {
            InfrastructureNameSpace,
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
    
    
    [Fact]
    public void Controllers_Should_Have_Dependency_On_Mediator()
    {
        // Arrange
        var assembly = typeof(Presentation.AssemblyReference).Assembly;
        
        // Act
        var result = Types
            .InAssembly(assembly)
            .That()
            .HaveNameEndingWith("Controller")
            .Should()
            .HaveDependencyOn("MediatoR")
            .GetResult();
        // Assert
        
        Assert.True(result.IsSuccessful);
    }
}