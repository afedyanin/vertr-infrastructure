# Git cli

## Get number of commits

https://stackoverflow.com/questions/677436/how-do-i-get-the-git-commit-count

```
git rev-list --count <revision>
```

## Squash all commits

https://www.squash.io/how-to-squash-all-commits-on-a-git-branch/

```
git checkout <branch-name>
git reset --soft HEAD~<number-of-commits>
git commit -m "New commit message"
git push --force
```

