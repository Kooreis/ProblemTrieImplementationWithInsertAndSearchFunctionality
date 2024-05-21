```python
class TrieNode:
    def __init__(self):
        self.children = {}
        self.endOfString = False

class Trie:
    def __init__(self):
        self.root = TrieNode()

    def insert(self, word):
        current = self.root
        for i in word:
            node = current.children.get(i)
            if node is None:
                node = TrieNode()
                current.children.update({i:node})
            current = node
        current.endOfString = True

    def search(self, word):
        current = self.root
        for i in word:
            node = current.children.get(i)
            if node is None:
                return False
            current = node
        if current.endOfString is True:
            return True
        return False

def main():
    trie = Trie()
    trie.insert("apple")
    print(trie.search("apple"))  # returns True
    print(trie.search("app"))    # returns False
    trie.insert("app")
    print(trie.search("app"))    # returns True

if __name__ == "__main__":
    main()
```