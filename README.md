# Bag o' Loot

This boilerplate code shows you how to display a command line prompt, read user input, and then based on the input value, execute other code. There is also example usage of a SQLite connection in the `DatabaseInterface.cs` file.

## Create Environment Variable

Before running the program, open your `.zshrc` file and put this new environment variable at the end.

```
export BAGOLOOT_DB="/Path/To/Where/You/Cloned/Your/Repo/bagoloot.db"
```

Then reload that file.

```
source ~/.zshrc
```

Now open up the project in Visual Studio code.

ERD for BagOloot
![Caption for the picture.](img/erd.png)