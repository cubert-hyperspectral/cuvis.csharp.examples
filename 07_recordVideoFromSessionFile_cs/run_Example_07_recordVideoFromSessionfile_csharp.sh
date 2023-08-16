#!/bin/bash

# Usage: 
# example app path 				[string] E.g. ./06_recordVideoNET.exe for windows	
# user settings directory 		[string] Default is C:/Program Files/cuvis/user/settings for windows or /etc/cuvis/user/settings for linux
# session file			        [string] Default is C:/Program Files/cuvis/sdk/sample_data/example_session/Ulm_001.cu3s for windows
# name of recording	directory	[string] The name of your output folder realtive to the example app path
# exposure time 				[int   ] exposure (integration) time in ms 
# auto exposure					[bool  ] 1 is "on", 0 is "off"; if "on" the aquisition will start with the given exposure time and then adjust on the fly 
# target fps					[double] Frames Per Second that shall be recorded. 


if [[ "$OSTYPE" == "linux-gnu"* ]]; then
    ##########LINUX##########
	echo "c sharp currently not supported"
	
else
    ##########WINDOWS##########
	../bin/07_recordVideoFromSessionfileNET.exe 									\
	"C:/Program Files/cuvis/user/settings"							\
	"C:/Program Files/cuvis/sdk/sample_data/set0_lab/x20p_calib_color.cu3s"	\
	"video01"																\
	100																		\
	0																		\
	2																		\
	2
fi
