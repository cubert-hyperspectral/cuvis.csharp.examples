#!/bin/bash

# Usage: 

# example app path 				[string] E.g. ./04_changeDistNET.exe  for windows 
# user settings directory 		[string] Default is ../../../sample_data/set_examples/settings
# measurement file (.cu3s)		[string] Default is ../../../sample_data/set_examples/set0_single/single.cu3s
# new distance 					[int   ] distance reference in mm
# name of export directory 		[string] The name of your output folder realtive to the example app path


if [[ "$OSTYPE" == "linux-gnu"* ]]; then
    ##########LINUX##########
	echo "c sharp currently not supported"																				
else
    ##########WINDOWS##########
	../bin/04_changeDistNET.exe 															\
	"../../../sample_data/set_examples/settings"						\
	"../../../sample_data/set_examples/set0_single/single.cu3s" 		\
	1000																					\
	"export"																				
fi
