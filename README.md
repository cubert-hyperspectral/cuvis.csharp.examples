# Cuvis C# examples

## Building
To the the exampels running, first clone this git repository and initialize it's submodules recursively

```
git submodule update --init --recursive
```

Next, you need to install the Cuvis C SDK (see https://cloud.cubert-gmbh.de/index.php/s/kKVtx0x2fmYqVgx), for running the examples, you'd probably like to use sample data (provided here: https://cloud.cubert-gmbh.de/index.php/s/3oECVGWpC1NpNqC)

For building the wrapper between C libraries and C#, you'll need SWIG (see https://www.swig.org/download.html).

Then use CMake (see https://cmake.org/download/) to configure and generate the Visual Studio project. You can configure either base directory (including all directoreis) or a single example using it's respective directory.
CMake will require you to locate the Cuvis C SDK (this should be found automatically, if the Cuvis C SDK is properly installed. Also, you need to point the variable *SWIG_EXECUTABLE* to the path of the *swig.exe*

## The examples

### 01_loadMeasurement
Load measurement from disk and print the value (count) for all available channels (wavelength) for one specific pixel.

### 02_reprocessMeasurement
Load measurement as well as references (dark, white, distance) from disk and reprocess the measurement to e.g. reflectance.

### 03_exportMeasurement
Load measurement from disk and save to different file formats.

### 04_changeDistance
Load measurement from disk and reprocess to a new distance.

### 05_recordSingleImages
Setup camera and record measurements via software trigger, aka "single shot mode" or "software mode".

### 06_recordVideo
Setup camera and record measurements via internal clock triggering, aka "video mode". In this example the worker is used to make use of multithreading (cuvis_worker_create).

### 07_recordVideoFromSessionFile
Setup a virtual camera based on a pre-recorded session file to simulate actual camera behaviour.