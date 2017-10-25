TIMEOUT /T 15
 
setx GPU_FORCE_64BIT_PTR 0
setx GPU_MAX_HEAP_SIZE 100
setx GPU_USE_SYNC_OBJECTS 1
setx GPU_MAX_ALLOC_PERCENT 100
setx GPU_SINGLE_ALLOC_PERCENT 100
 
EthDcrMiner64.exe -epool etc-us-east1.nanopool.org:19999 -ewal 0x5e1c690261b4824ac46523aea650b57076f330ad.W02/gonzalo-alberto@outlook.com -epsw x -mode 1 -ftime 10
