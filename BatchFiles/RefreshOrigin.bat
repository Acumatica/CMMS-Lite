@ECHO OFF
COLOR 2
git update-git-for-windows
CD ../
git remote update origin --prune
PAUSE