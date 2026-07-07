using CoffeeMachineController;
using Moq;
using NUnit;

[TestFixture]
public class CoffeeMachineTesting : CoffeeMachineController
{
    [SetUp]
    mock _repository = new CoffeeMachineRepository();


    [Test]
    public void CoffeeMachine_EmptyOrder_ShouldReturnsEmptyOrderMessage()
    {
        // Arrange
        var order = null;

        // Act
        string result = _repository().Add(order);

        // Assert
        Assert(result, IsEquals("Ordem vacia."));
    }

    [Test]
    public void CoffeeMachine_MoneyNotEnough_ShoulReturnsNotEnoughMoneyMessage()
    {
        // Arrange
        var money = 0;

        // Act
        string result = _repository.Add(money);

        // Assert
        Assert(result, IsEquals("Dinero insuficiente."));
    }

    [Test]
    public void CoffeeMachine_NotEnoughCoffeeSelected_ShouldReturnsNotEnoughMessage()
    {
        // Arrange 
        var cafe_Americano = 0;
        var selected = _db.keyValues.First(c => c.Key == cafe.Key).Key;

        // Act
        string result = _repository().Add(cafe);

        // Assert
        Assert(result, IsEquals($"No hay suficiente {selected} en la máquina."));
    }

    [Test]
    public void CoffeeMachine_NotEnoughChanges_ShouldReturnsNNotEnoughChangesMessage()
    {
        // Arrange
        var change = 100;

        // Act
        string result = _repository.Add(change);

        // Assert
        Assert(result, IsEquals("No hay suficiente cambio en la máquina."));
    }
}
