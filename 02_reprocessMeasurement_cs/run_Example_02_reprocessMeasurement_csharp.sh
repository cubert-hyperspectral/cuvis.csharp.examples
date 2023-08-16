#!/bin/bash

# Usage: 
# example app path 				[string] E.g. ./02_reprocessMeasuNET.exe for windows
# user settings directory 		[string] Default is ../../../sample_data/set_examples/settings
# measurement file (.cu3)		[string] Default is ../../../sample_data/set_examples/set0_lab/x20_calib_color_raw.cu3s
# dark file (.cu3)				[string] Default is ../../../sample_data/set_examples/set0_lab/x20_calib_color_dark.cu3s
# white file (.cu3)				[string] Default is ../../../sample_data/set_examples/set0_lab/x20_calib_color_white.cu3s
# distance file (.cu3)			[string] Default is ../../../sample_data/set_examples/set0_lab/x20_calib_color_distance.cu3s
# name of output directory 		[string] The name of your output folder realtive to the example app path



if [[ "$OSTYPE" == "linux-gnu"* ]]; then
    ##########LINUX##########
	echo "c sharp currently not supported"
else
    ##########WINDOWS##########
	../bin/02_reprocessMeasuNET.exe 								\
	"../../../sample_data/set_examples/settings"					\
	"../../../sample_data/set_examples/set0_lab/x20_calib_color_raw.cu3s" 		\
	"../../../sample_data/set_examples/set0_lab/x20_calib_color_dark.cu3s"		\
	"../../../sample_data/set_examples/set0_lab/x20_calib_color_white.cu3s"		\
	"../../../sample_data/set_examples/set0_lab/x20_calib_color_distance.cu3s"	\
	"reprocessed"													\
	
fi
