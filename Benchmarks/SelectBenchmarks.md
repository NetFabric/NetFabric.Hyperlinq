## SelectBenchmarks

### Source
[SelectBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/SelectBenchmarks.cs)

### References:
- Linq: 4.8.4300.0
- System.Linq.Async: [5.0.0](https://www.nuget.org/packages/System.Linq.Async/5.0.0)
- System.Interactive: [5.0.0](https://www.nuget.org/packages/System.Interactive/5.0.0)
- System.Interactive.Async: [5.0.0](https://www.nuget.org/packages/System.Interactive.Async/5.0.0)
- StructLinq: [0.19.3](https://www.nuget.org/packages/StructLinq/0.19.3)
- NetFabric.Hyperlinq: [3.0.0-beta27](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta27)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
  [Host]        : .NET Framework 4.8 (4.8.4300.0), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|                           Method |           Categories | Count |       Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------------------- |--------------------- |------ |-----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|                       Linq_Array |                Array |   100 |   825.8 ns |  7.91 ns |  7.02 ns |  1.00 |    0.00 | 0.0229 |     - |     - |      48 B |
|                 StructLinq_Array |                Array |   100 |   280.1 ns |  2.46 ns |  2.30 ns |  0.34 |    0.00 |      - |     - |     - |         - |
|              Hyperlinq_Array_For |                Array |   100 |   281.0 ns |  3.90 ns |  3.65 ns |  0.34 |    0.00 |      - |     - |     - |         - |
|          Hyperlinq_Array_Foreach |                Array |   100 |   249.5 ns |  4.85 ns |  5.59 ns |  0.30 |    0.01 |      - |     - |     - |         - |
|               Hyperlinq_Span_For |                Array |   100 |   249.0 ns |  4.88 ns |  4.56 ns |  0.30 |    0.01 |      - |     - |     - |         - |
|           Hyperlinq_Span_Foreach |                Array |   100 |   263.3 ns |  5.19 ns |  5.77 ns |  0.32 |    0.01 |      - |     - |     - |         - |
|             Hyperlinq_Memory_For |                Array |   100 |   332.5 ns |  2.57 ns |  2.41 ns |  0.40 |    0.01 |      - |     - |     - |         - |
|         Hyperlinq_Memory_Foreach |                Array |   100 |   285.5 ns |  4.49 ns |  3.98 ns |  0.35 |    0.01 |      - |     - |     - |         - |
|                                  |                      |       |            |          |          |       |         |        |       |       |           |
|            Linq_Enumerable_Value |     Enumerable_Value |   100 | 1,512.1 ns | 22.76 ns | 23.37 ns |  1.00 |    0.00 | 0.0420 |     - |     - |      88 B |
|      StructLinq_Enumerable_Value |     Enumerable_Value |   100 |   949.7 ns | 17.09 ns | 15.99 ns |  0.63 |    0.02 | 0.0153 |     - |     - |      32 B |
|       Hyperlinq_Enumerable_Value |     Enumerable_Value |   100 |   251.2 ns |  5.10 ns |  5.67 ns |  0.17 |    0.01 |      - |     - |     - |         - |
|                                  |                      |       |            |          |          |       |         |        |       |       |           |
|            Linq_Collection_Value |     Collection_Value |   100 | 1,549.2 ns | 16.36 ns | 12.78 ns |  1.00 |    0.00 | 0.0420 |     - |     - |      88 B |
|      StructLinq_Collection_Value |     Collection_Value |   100 |   943.8 ns | 12.30 ns | 10.27 ns |  0.61 |    0.01 | 0.0153 |     - |     - |      32 B |
|       Hyperlinq_Collection_Value |     Collection_Value |   100 |   265.5 ns |  2.98 ns |  2.49 ns |  0.17 |    0.00 |      - |     - |     - |         - |
|                                  |                      |       |            |          |          |       |         |        |       |       |           |
|                  Linq_List_Value |           List_Value |   100 | 1,551.0 ns | 21.50 ns | 20.11 ns |  1.00 |    0.00 | 0.0420 |     - |     - |      88 B |
|            StructLinq_List_Value |           List_Value |   100 |   982.3 ns | 19.00 ns | 21.12 ns |  0.63 |    0.02 | 0.0153 |     - |     - |      32 B |
|         Hyperlinq_List_Value_For |           List_Value |   100 |   443.9 ns |  7.98 ns |  6.66 ns |  0.29 |    0.00 |      - |     - |     - |         - |
|     Hyperlinq_List_Value_Foreach |           List_Value |   100 |   485.1 ns |  5.47 ns |  5.12 ns |  0.31 |    0.00 |      - |     - |     - |         - |
|                                  |                      |       |            |          |          |       |         |        |       |       |           |
|        Linq_Enumerable_Reference | Enumerable_Reference |   100 | 1,280.5 ns | 20.79 ns | 19.45 ns |  1.00 |    0.00 | 0.0420 |     - |     - |      88 B |
|  StructLinq_Enumerable_Reference | Enumerable_Reference |   100 |   720.8 ns | 10.02 ns |  9.37 ns |  0.56 |    0.01 | 0.0153 |     - |     - |      32 B |
|   Hyperlinq_Enumerable_Reference | Enumerable_Reference |   100 |   689.8 ns | 12.27 ns | 11.47 ns |  0.54 |    0.01 | 0.0153 |     - |     - |      32 B |
|                                  |                      |       |            |          |          |       |         |        |       |       |           |
|        Linq_Collection_Reference | Collection_Reference |   100 | 1,276.7 ns | 25.61 ns | 25.15 ns |  1.00 |    0.00 | 0.0420 |     - |     - |      88 B |
|  StructLinq_Collection_Reference | Collection_Reference |   100 |   674.0 ns |  8.60 ns |  8.05 ns |  0.53 |    0.01 | 0.0153 |     - |     - |      32 B |
|   Hyperlinq_Collection_Reference | Collection_Reference |   100 |   713.0 ns |  8.20 ns |  6.85 ns |  0.56 |    0.01 | 0.0153 |     - |     - |      32 B |
|                                  |                      |       |            |          |          |       |         |        |       |       |           |
|              Linq_List_Reference |       List_Reference |   100 | 1,199.8 ns | 10.64 ns |  8.89 ns |  1.00 |    0.00 | 0.0420 |     - |     - |      88 B |
|        StructLinq_List_Reference |       List_Reference |   100 |   679.3 ns |  8.86 ns | 11.83 ns |  0.57 |    0.01 | 0.0153 |     - |     - |      32 B |
|     Hyperlinq_List_Reference_For |       List_Reference |   100 |   431.1 ns |  6.23 ns |  5.83 ns |  0.36 |    0.01 |      - |     - |     - |         - |
| Hyperlinq_List_Reference_Foreach |       List_Reference |   100 |   485.6 ns |  9.13 ns |  8.97 ns |  0.40 |    0.01 |      - |     - |     - |         - |
