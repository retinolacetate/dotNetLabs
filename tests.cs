using Xunit;
using Lab1_2SortedList;
using System;
using System.Collections.Generic;

public class tests
{
    [Fact]
    public void TestInsertLast()
    {   // Arrange
        MySortedList SortedList = new MySortedList();
        List<int> List = new List<int>(new[] { 1, 2, 3, 4});

        // Assert
        Assert.Equal(0, SortedList.Count());

        // Act
        foreach(var Element in List) SortedList.AddLast(Element);

        // Assert
        Assert.Equal(4, SortedList.Count());
    } 

    [Fact]
    public void TestInsertFirst()
    {   // Arrange
        MySortedList SortedList = new MySortedList();
        List<int> List = new List<int>(new[] { 1, 2, 3, 4});

        // Assert
        Assert.Equal(0, SortedList.Count());

        // Act
        foreach(var Element in List) SortedList.AddFirst(Element);

        // Assert
        Assert.Equal(4, SortedList.Count());
    }

    [Fact]
    public void TestInsertWithSort()
    {   // Arrange
        MySortedList SortedList = new MySortedList();
        List<int> List = new List<int>(new[] { 1, 2, 3, 4});

        // Assert
        Assert.Equal(0, SortedList.Count());

        // Act
        foreach(var Element in List) SortedList.AddWithSort(Element);

        // Assert
        Assert.Equal(4, SortedList.Count());
    }

    [Fact]
    public void TestDeletionByIndex_True()
    {   // Arrange
        MySortedList SortedList = new MySortedList();
        List<int> List = new List<int>(new[] { 1, 2, 3, 4});

        // Act
        foreach(var Element in List) SortedList.AddWithSort(Element);
        SortedList.DeleteByIndex(0);

        // Assert
        Assert.Equal(3, SortedList.Count());
    }

    [Fact]
    public void TestDeletionByIndex_FromClearList()
    {   // Arrange
        MySortedList SortedList = new MySortedList();

        // Act + Assert
        Assert.Throws<ArgumentException>(() => SortedList.DeleteByIndex(1));
    }

    [Fact]
    public void TestDeletion_NotExistingNode()
    {   // Arrange
        MySortedList SortedList = new MySortedList();
        List<int> List = new List<int>(new[] { 1, 2, 3, 4});

        // Act + Assert
        foreach(var Element in List) SortedList.AddWithSort(Element);
            Assert.Throws<ArgumentException>(() => SortedList.DeleteByIndex(5));
    }

    [Fact]
    public void TestClear()
    {   // Arrange
        MySortedList SortedList = new MySortedList();
        List<int> List2 = new List<int>(new[] { 1, 2, 3, 4});

        // Act
        foreach(var Element in List2) SortedList.AddWithSort(Element);
        SortedList.Clear("SortedList");

        // Assert
        Assert.Equal(0, SortedList.Count());
    }

    [Fact]
    public void TestFindByValue()
    {   // Arrange
        MySortedList SortedList = new MySortedList();
        List<int> List = new List<int>(new[] { 1, 2, 3, 4});

        // Act
        foreach(var Element in List) SortedList.AddWithSort(Element);

        // Assert
        Assert.Equal(0, SortedList.FindByValue(1));
    }

    [Fact]
    public void TestToUnit()
    {   // Arrange
        MySortedList SortedList1 = new MySortedList();
        MySortedList SortedList2 = new MySortedList();
        MySortedList SortedListUnit = new MySortedList();
        List<int> List = new List<int>(new[] { 1, 2, 3, 4});

        // Act
        foreach(var Element in List){
            SortedList1.AddWithSort(Element+5);
            SortedList2.AddWithSort(Element); 
        }

        // Assert
        SortedListUnit = MySortedList.ToUnite(SortedList1, SortedList2);
        Assert.Equal(8, SortedListUnit.Count());
    }

    [Fact]
    public void TestToIntersect()
    {   // Arrange
        MySortedList SortedList1 = new MySortedList();
        MySortedList SortedList2 = new MySortedList();
        MySortedList SortedListIntersect = new MySortedList();
        List<int> List = new List<int>(new[] { 1, 2, 3, 4});

        // Act
        foreach(var Element in List){
            SortedList1.AddWithSort(Element);
            SortedList2.AddWithSort(Element); 
        }

        // Assert
        SortedListIntersect = MySortedList.ToIntersect(SortedList1, SortedList2);
        Assert.Equal(4, SortedListIntersect.Count());
    }

    [Fact]
    public void TestFindDiffrence()
    {   // Arrange
        MySortedList SortedList1 = new MySortedList();
        MySortedList SortedList2 = new MySortedList();
        MySortedList SortedListIntersect = new MySortedList();
        List<int> List = new List<int>(new[] { 1, 2, 3, 4});

        // Act
        foreach(var Element in List){
            SortedList1.AddWithSort(Element+1);
            SortedList2.AddWithSort(Element); 
        }

        // Assert
        SortedListIntersect = MySortedList.FindDiffrence(SortedList1, SortedList2);
        Assert.Equal(1, SortedListIntersect.Count());
    }

}
