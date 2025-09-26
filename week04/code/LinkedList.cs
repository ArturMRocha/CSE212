using System.Collections;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// A classe Node representa um único item em uma lista duplamente encadeada.
/// </summary>
public class LinkedListNode
{
    public int Value { get; set; }
    public LinkedListNode? Next { get; set; }
    public LinkedListNode? Prev { get; set; }

    public LinkedListNode(int value)
    {
        Value = value;
        this.Next = null;
        Prev = null;
    }
}

public class LinkedList : IEnumerable<int>
{
    private LinkedListNode? _head;
    private LinkedListNode? _tail;

    /// <summary>
    /// Insere um novo nó na frente (cabeça) da lista encadeada.
    /// </summary>
    public void InsertHead(int value)
    {
        LinkedListNode newNode = new(value);
        if (_head is null)
        {
            _head = newNode;
            _tail = newNode;
        }
        else
        {
            newNode.Next = _head;
            _head.Prev = newNode;
            _head = newNode;
        }
    }

    /// <summary>
    /// Insere um novo nó no final (cauda) da lista encadeada.
    /// </summary>
    public void InsertTail(int value)
    {
        // Cria um novo nó
        LinkedListNode newNode = new(value);
        // Se a lista estiver vazia, cabeça e cauda apontam para o novo nó.
        if (_tail is null)
        {
            _head = newNode;
            _tail = newNode;
        }
        // Se a lista não estiver vazia, apenas a cauda será afetada.
        else
        {
            newNode.Prev = _tail;     // Conecta o novo nó à cauda anterior
            _tail.Next = newNode;     // Conecta a cauda anterior ao novo nó
            _tail = newNode;          // Atualiza a cauda para apontar para o novo nó
        }
    }

    /// <summary>
    /// Remove o primeiro nó (cabeça) da lista encadeada.
    /// </summary>
    public void RemoveHead()
    {
        if (_head == _tail)
        {
            _head = null;
            _tail = null;
        }
        else if (_head is not null)
        {
            _head.Next!.Prev = null;
            _head = _head.Next;
        }
    }

    /// <summary>
    /// Remove o último nó (cauda) da lista encadeada.
    /// </summary>
    public void RemoveTail()
    {
        // Se a lista tem apenas um item, defina head e tail como null.
        if (_head == _tail)
        {
            _head = null;
            _tail = null;
        }
        // Se a lista tem mais de um item, apenas a cauda é afetada.
        else if (_tail is not null)
        {
            _tail.Prev!.Next = null; // Desconecta o penúltimo nó do último
            _tail = _tail.Prev;      // Atualiza a cauda para ser o penúltimo nó
        }
    }

    /// <summary>
    /// Insere 'newValue' após a primeira ocorrência de 'value' na lista encadeada.
    /// </summary>
    public void InsertAfter(int value, int newValue)
    {
        LinkedListNode? curr = _head;
        while (curr is not null)
        {
            if (curr.Value == value)
            {
                if (curr == _tail)
                {
                    InsertTail(newValue);
                }
                else
                {
                    LinkedListNode newNode = new(newValue);
                    newNode.Prev = curr;
                    newNode.Next = curr.Next;
                    curr.Next!.Prev = newNode;
                    curr.Next = newNode;
                }
                return;
            }
            curr = curr.Next;
        }
    }

    /// <summary>
    /// Remove o primeiro nó que contém 'value'.
    /// </summary>
    public void Remove(int value)
    {
        LinkedListNode? curr = _head;
        while (curr is not null)
        {
            if (curr.Value == value)
            {
                if (curr == _head)
                {
                    RemoveHead();
                }
                else if (curr == _tail)
                {
                    RemoveTail();
                }
                else
                {
                    curr.Prev!.Next = curr.Next;
                    curr.Next!.Prev = curr.Prev;
                }
                return;
            }
            curr = curr.Next;
        }
    }

    /// <summary>
    /// Procura por todas as instâncias de 'oldValue' e substitui o valor por 'newValue'.
    /// </summary>
    public void Replace(int oldValue, int newValue)
    {
        LinkedListNode? curr = _head;
        while (curr is not null)
        {
            if (curr.Value == oldValue)
            {
                curr.Value = newValue;
            }
            curr = curr.Next;
        }
    }

    /// <summary>
    /// Fornece (yields) todos os valores na lista encadeada.
    /// </summary>
    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    /// <summary>
    /// Itera para a frente através da Lista Encadeada.
    /// </summary>
    public IEnumerator<int> GetEnumerator()
    {
        var curr = _head;
        while (curr is not null)
        {
            yield return curr.Value;
            curr = curr.Next;
        }
    }

    /// <summary>
    /// Itera para trás através da Lista Encadeada.
    /// </summary>
    public IEnumerable Reverse()
    {
        var curr = _tail; // Começa no final
        while (curr is not null)
        {
            yield return curr.Value; // Fornece o item
            curr = curr.Prev;       // Vai para trás na lista
        }
    }

    public override string ToString()
    {
        return "<LinkedList>{" + string.Join(", ", this) + "}";
    }
    
    // Apenas para testes.
    public bool HeadAndTailAreNull()
    {
        return _head is null && _tail is null;
    }

    // Apenas para testes.
    public bool HeadAndTailAreNotNull()
    {
        return _head is not null && _tail is not null;
    }
}

public static class IntArrayExtensionMethods {
    public static string AsString(this IEnumerable array) {
        return "<IEnumerable>{" + string.Join(", ", array.Cast<int>()) + "}";
    }
}