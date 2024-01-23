// The following ifdef block is the standard way of creating macros which make exporting
// from a DLL simpler. All files within this DLL are compiled with the JANEONLIB_EXPORTS
// symbol defined on the command line. This symbol should not be defined on any project
// that uses this DLL. This way any other project whose source files include this file see
// JANEONLIB_API functions as being imported from a DLL, whereas this DLL sees symbols
// defined with this macro as being exported.
#ifdef JANEONLIB_EXPORTS
#define JANEONLIB_API __declspec(dllexport)
#else
#define JANEONLIB_API __declspec(dllimport)
#endif

// This class is exported from the dll
class JANEONLIB_API CJANeonLib {
public:
	CJANeonLib(void);
	// TODO: add your methods here.
};

extern JANEONLIB_API int nJANeonLib;

JANEONLIB_API int fnJANeonLib(void);
