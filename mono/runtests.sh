#!/bin/bash
#===============================================================================
#
#          FILE:  runtests.sh
# 
#         USAGE:  ./runtests.sh 
# 
#   DESCRIPTION:  Small script for running the tests
# 
#       OPTIONS:  ---
#  REQUIREMENTS:  ---
#          BUGS:  ---
#         NOTES:  ---
#        AUTHOR:  Andreas Augustin (), andy.augustin@t-online.de
#       COMPANY:  
#       VERSION:  1.0
#       CREATED:  03/08/2016 08:57:13 PM CET
#      REVISION:  ---
#===============================================================================

mono ../packages/SpecRun.Runner.*/tools/SpecRun.exe run Default.srprofile "/baseFolder:." /log:specrun.log

