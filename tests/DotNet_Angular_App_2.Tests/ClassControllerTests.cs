using System.Threading.Tasks;
using DotNet_Angular_App_2.Controllers;
using DotNet_Angular_App_2.Models;
using DotNet_Angular_App_2.Repositories;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;

namespace DotNet_Angular_App_2.Tests;

[TestFixture]
public class ClassControllerTests
{
    private Mock<IClassRepository> _repository = null!;
    private ClassController _controller = null!;

    [SetUp]
    public void SetUp()
    {
        _repository = new Mock<IClassRepository>();
        _controller = new ClassController(_repository.Object);
    }

    [Test]
    public async Task GetStudentById_WhenMissing_ReturnsNotFound()
    {
        _repository.Setup(x => x.GetStudentById(99)).ReturnsAsync((Class?)null);
        var result = await _controller.GetStudentById(99);
        Assert.That(result, Is.TypeOf<NotFoundResult>());
    }

    [Test]
    public async Task GetStudentById_WhenFound_ReturnsOk()
    {
        var student = new Class { Id = 1, Name = "Alice", Grade = 'A', IsPassed = true };
        _repository.Setup(x => x.GetStudentById(1)).ReturnsAsync(student);
        var result = await _controller.GetStudentById(1);
        var ok = result as OkObjectResult;
        Assert.That(ok, Is.Not.Null);
        Assert.That(ok!.Value, Is.SameAs(student));
    }

    [Test]
    public async Task AddStudent_ReturnsCreatedAtAction()
    {
        var student = new Class { Name = "Alice", Grade = 'A', IsPassed = true };
        _repository.Setup(x => x.AddAsync(student)).Callback(() => student.Id = 7).Returns(Task.CompletedTask);
        var result = await _controller.AddStudent(student);
        Assert.That(result, Is.TypeOf<CreatedAtActionResult>());
        _repository.Verify(x => x.AddAsync(student), Times.Once);
    }

    [Test]
    public async Task UpdateStudent_WhenIdsDiffer_ReturnsBadRequest()
    {
        var student = new Class { Id = 2, Name = "Alice", Grade = 'A' };
        var result = await _controller.UpdateStudent(1, student);
        Assert.That(result, Is.TypeOf<BadRequestObjectResult>());
        _repository.Verify(x => x.UpdateAsync(It.IsAny<Class>()), Times.Never);
    }

    [Test]
    public async Task UpdateStudent_WhenMissing_ReturnsNotFound()
    {
        var student = new Class { Id = 1, Name = "Alice", Grade = 'A' };
        _repository.Setup(x => x.GetStudentById(1)).ReturnsAsync((Class?)null);
        var result = await _controller.UpdateStudent(1, student);
        Assert.That(result, Is.TypeOf<NotFoundResult>());
    }

    [Test]
    public async Task DeleteStudent_WhenFound_ReturnsNoContent()
    {
        _repository.Setup(x => x.GetStudentById(1)).ReturnsAsync(new Class { Id = 1 });
        var result = await _controller.DeleteStudent(1);
        Assert.That(result, Is.TypeOf<NoContentResult>());
        _repository.Verify(x => x.DeleteAsync(1), Times.Once);
    }
}
