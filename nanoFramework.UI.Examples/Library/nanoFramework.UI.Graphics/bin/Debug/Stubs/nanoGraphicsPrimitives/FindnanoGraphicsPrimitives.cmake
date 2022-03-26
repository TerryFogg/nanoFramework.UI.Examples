#
# Copyright (c) .NET Foundation and Contributors
# See LICENSE file in the project root for full license information.
#

# native code directory
set(BASE_PATH_FOR_THIS_MODULE ${BASE_PATH_FOR_CLASS_LIBRARIES_MODULES}/nanoGraphicsPrimitives)


# set include directories
list(APPEND nanoGraphicsPrimitives_INCLUDE_DIRS ${PROJECT_SOURCE_DIR}/src/CLR/Core)
list(APPEND nanoGraphicsPrimitives_INCLUDE_DIRS ${PROJECT_SOURCE_DIR}/src/CLR/Include)
list(APPEND nanoGraphicsPrimitives_INCLUDE_DIRS ${PROJECT_SOURCE_DIR}/src/HAL/Include)
list(APPEND nanoGraphicsPrimitives_INCLUDE_DIRS ${PROJECT_SOURCE_DIR}/src/PAL/Include)
list(APPEND nanoGraphicsPrimitives_INCLUDE_DIRS ${BASE_PATH_FOR_THIS_MODULE})
list(APPEND nanoGraphicsPrimitives_INCLUDE_DIRS ${PROJECT_SOURCE_DIR}/src/nanoGraphicsPrimitives)

# source files
set(nanoGraphicsPrimitives_SRCS

    nanoFramework_Graphics.cpp


    nanoFramework_Graphics_nanoFramework_UI_Bitmap.cpp
    nanoFramework_Graphics_nanoFramework_UI_DisplayControl.cpp
    nanoFramework_Graphics_nanoFramework_UI_Font.cpp

)

foreach(SRC_FILE ${nanoGraphicsPrimitives_SRCS})

    set(nanoGraphicsPrimitives_SRC_FILE SRC_FILE-NOTFOUND)

    find_file(nanoGraphicsPrimitives_SRC_FILE ${SRC_FILE}
        PATHS
	        ${BASE_PATH_FOR_THIS_MODULE}
	        ${TARGET_BASE_LOCATION}
            ${PROJECT_SOURCE_DIR}/src/nanoGraphicsPrimitives

	    CMAKE_FIND_ROOT_PATH_BOTH
    )

    if (BUILD_VERBOSE)
        message("${SRC_FILE} >> ${nanoGraphicsPrimitives_SRC_FILE}")
    endif()

    list(APPEND nanoGraphicsPrimitives_SOURCES ${nanoGraphicsPrimitives_SRC_FILE})

endforeach()

include(FindPackageHandleStandardArgs)

FIND_PACKAGE_HANDLE_STANDARD_ARGS(nanoGraphicsPrimitives DEFAULT_MSG nanoGraphicsPrimitives_INCLUDE_DIRS nanoGraphicsPrimitives_SOURCES)
