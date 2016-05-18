Tangram_Interfaces
=========
Interfaces for inter project datatype binding of the tangram project and all its' parts


## Intension:

Share Interface definitions with other external projects to allow for extensibility of Tangram e.g. with other pin-matrix devices or interaction handlers.

## How to use:

Simply add it as reference. **Attention:** Watch out the needed reference from a submodule!

### References needed (dll)

- [BrailleIO](https://github.com/TUD-INF-IAI-MCI/BrailleIO) : `BrailleIO_Interfaces` is included as a dll in the lib folder. Should be replaced by newer versions if necessary.


## The beautiful OrderedConcurrentDictionary

In this project the class `OrderedConcurrentDictionary` is implemented, which allows to set up thread-save `ConcurrentDictionary` with the ability to be sorted. 

The default sorting is by the adding timestamp of the `KeyValuePair`. But a specialized [`IComparer`](https://msdn.microsoft.com/de-de/library/system.collections.icomparer(v=vs.110).aspx) have to be given within the constructor to determine the sorting of elements.

## You want to know more?

--	TODO: build help from code doc

For getting a very detailed overview use the [code documentation section](/Help/index.html) of this project.

