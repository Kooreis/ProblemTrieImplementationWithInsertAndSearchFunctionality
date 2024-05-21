```C#
using System;
using System.Collections.Generic;

public class TrieNode
{
    public Dictionary<char, TrieNode> Children = new Dictionary<char, TrieNode>();
    public bool EndOfWord;
}

public class Trie
{
    private readonly TrieNode _root;

    public Trie()
    {
        _root = new TrieNode();
    }

    public void Insert(string word)
    {
        var currentNode = _root;
        for (var i = 0; i < word.Length; i++)
        {
            if (!currentNode.Children.ContainsKey(word[i]))
            {
                currentNode.Children[word[i]] = new TrieNode();
            }

            currentNode = currentNode.Children[word[i]];
        }

        currentNode.EndOfWord = true;
    }

    public bool Search(string word)
    {
        var currentNode = _root;
        for (var i = 0; i < word.Length; i++)
        {
            if (!currentNode.Children.ContainsKey(word[i]))
            {
                return false;
            }

            currentNode = currentNode.Children[word[i]];
        }

        return currentNode != null && currentNode.EndOfWord;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Trie trie = new Trie();
        trie.Insert("hello");
        trie.Insert("world");
        Console.WriteLine(trie.Search("hello")); // True
        Console.WriteLine(trie.Search("world")); // True
        Console.WriteLine(trie.Search("hell")); // False
        Console.WriteLine(trie.Search("worl")); // False
    }
}
```