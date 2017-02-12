@echo off

SET /A test=%RANDOM%

:loop

echo Writing to file: Logs\time%test%.txt
echo %RANDOM% - %DATE% / %TIME% >> Logs\time%test%.txt
ping -n 9 127.0.0.1 >nul

goto loop