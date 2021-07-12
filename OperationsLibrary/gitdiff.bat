set iter=%1
set initial=%2
set final=%3
git diff --diff-filter=ACMRTUXB --name-only %initial% %final% > diff.txt
set /p DIFF=<diff.txt
git archive --output=archived_changes%iter%.zip HEAD %DIFF%
del diff.txt