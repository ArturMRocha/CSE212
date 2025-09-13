using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue multiple items, including two with the same highest priority.
    //           The test verifies that the first one added (FIFO) is the first one dequeued.
    // Expected Result: Dequeue should return "Second" (first item with priority 10), then "Fourth"
    //                  (second item with priority 10).
    // Defect(s) Found: 
    // 1. The use of '>=' in the comparison logic violates the FIFO tie-breaker rule, returning the LAST item with the highest priority.
    // 2. The item is never actually removed from the queue after being dequeued.
    public void TestPriorityQueue_Tiebreaker()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("First", 5);
        priorityQueue.Enqueue("Second", 10);
        priorityQueue.Enqueue("Third", 5);
        priorityQueue.Enqueue("Fourth", 10);
        
        var result1 = priorityQueue.Dequeue();
        Assert.AreEqual("Second", result1);

        var result2 = priorityQueue.Dequeue();
        Assert.AreEqual("Fourth", result2);
    }

    [TestMethod]
    // Scenario: Enqueue items where the highest priority item is the last one added.
    //           Then, dequeue all items and check the queue's state.
    // Expected Result: Returns "Third" (highest priority). After all items are dequeued,
    //                  the queue should be empty, represented as "[]".
    // Defect(s) Found: 
    // 1. The loop condition `index < _queue.Count - 1` prevents the last element from being checked.
    // 2. The item is not removed from the queue, so the queue is never empty.
    public void TestPriorityQueue_BoundaryAndRemoval()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("First", 1);
        priorityQueue.Enqueue("Second", 2);
        priorityQueue.Enqueue("Third", 3); // Highest priority is at the end.
        
        Assert.AreEqual("Third", priorityQueue.Dequeue());
        Assert.AreEqual("Second", priorityQueue.Dequeue());
        Assert.AreEqual("First", priorityQueue.Dequeue());
        Assert.AreEqual("[]", priorityQueue.ToString());
    }

    [TestMethod]
    // Scenario: Attempt to dequeue from an empty queue.
    // Expected Result: An InvalidOperationException should be thrown.
    // Defect(s) Found: None. The empty check works correctly.
    public void TestPriorityQueue_EmptyQueueException()
    {
        var priorityQueue = new PriorityQueue();
        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("An exception should have been thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
        catch (Exception)
        {
            Assert.Fail("An InvalidOperationException was expected.");
        }
    }
}