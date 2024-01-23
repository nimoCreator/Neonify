// JANeonLib.cpp : Defines the exported functions for the DLL.
//

#include "pch.h"
#include "framework.h"
#include "JANeonLib.h"


// This is an example of an exported variable
JANEONLIB_API int nJANeonLib=0;

// This is an example of an exported function.
JANEONLIB_API int fnJANeonLib(void)
{
    return 0;
}

// This is the constructor of a class that has been exported.
CJANeonLib::CJANeonLib()
{
    return;
}
