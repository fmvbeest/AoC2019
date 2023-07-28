namespace AoC2019.Util;

public interface INode
{
    public string Name { get; set; }
    public bool IsDirectory();
    public Directory GetParent();
}

public class Directory : INode
{
    public string Name { get; set; }
    private readonly Directory _parent;
    private readonly List<Directory> _directories;
    private readonly List<File> _files;

    public Directory(string name, Directory parent)
    {
        Name = name;
        _directories = new List<Directory>();
        _files = new List<File>();
        _parent = parent;
    }

    public bool IsDirectory() => true;

    public Directory GetParent() => _parent;

    public void AddDir(Directory directory) => _directories.Add(directory);

    public void AddFile(File file) => _files.Add(file);

    public bool ContainsDirectory(string name) => _directories.Any(d => d.Name.Equals(name));

    public Directory GetDirectory(string name) => _directories.First(d => d.Name.Equals(name));

    public long Size()
    {
        return _files.Sum(file => file.Size) + _directories.Sum(dir => dir.Size());
    }

    public List<Directory> ListDirectories(List<Directory> list)
    {
        foreach (var dir in _directories)
        {
            list.Add(dir);
            dir.ListDirectories(list);
        }

        return list;
    }
}

public class File : INode
{
    public string Name { get; set; }
    private readonly Directory _parent;
    
    public long Size { get; }
    
    public File(string name, long size, Directory parent)
    {
        Name = name;
        Size = size;
        _parent = parent;
    }
    
    public bool IsDirectory() => false;

    public Directory GetParent() => _parent;
}