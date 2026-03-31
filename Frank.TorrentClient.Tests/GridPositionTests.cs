using Frank.TorrentClient.Gui3.UserControls;

using Xunit;

namespace Frank.TorrentClient.Tests;

public class GridPositionTests
{
    [Fact]
    public void Test()
    {
        // Arrange
        var expectedX = 10u;
        var expectedY = 20u;
    
        // Act
        var gridPosition = new GridPosition(expectedX, expectedY);
    
        // Assert
        Assert.Equal(expectedX, gridPosition.Row);
        Assert.Equal(expectedY, gridPosition.Column);
    }
}

public class GridBuilderTests
{
    
}