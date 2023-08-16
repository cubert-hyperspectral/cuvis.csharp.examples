#!/bin/bash


# Usage:
# example app path 				[string] E.g. ./01_loadMeasuNET.exe  for windows
# user settings directory 		[string] Default is ../../../sample_data/set_examples/settings
# measurement file (.cu3)		[string] Default is ../../../sample_data/set_examples/set4_tractor/complete.cu3s

if [[ "$OSTYPE" == "linux-gnu"* ]]; then
    ##########LINUX##########
	echo "c sharp currently not supported"


else
    ##########WINDOWS##########
	../bin/01_loadMeasuNET.exe 										\
	"../../../sample_data/set_examples/settings"					\
	"../../../sample_data/set_examples/set4_tractor/complete.cu3s"	\


fi

