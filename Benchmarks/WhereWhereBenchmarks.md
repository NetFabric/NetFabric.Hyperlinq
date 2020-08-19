## WhereWhereBenchmarks

### References:
- StructLinq.BCL: [0.19.1](https://www.nuget.org/packages/StructLinq.BCL/0.19.1)
- NetFabric.Hyperlinq: [3.0.0-beta25](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta25)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.100-preview.7.20366.6
  [Host]        : .NET Core 5.0.0 (CoreCLR 5.0.20.36411, CoreFX 5.0.20.36411), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.0 (CoreCLR 5.0.20.36411, CoreFX 5.0.20.36411), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|                         Method |           Categories | Count |       Mean |    Error |   StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------- |--------------------- |------ |-----------:|---------:|---------:|------:|-------:|------:|------:|----------:|
|                     Linq_Range |                Range |   100 | 1,107.7 ns |  4.28 ns |  3.57 ns |  1.00 | 0.1183 |     - |     - |     248 B |
|                Hyperlinq_Range |                Range |   100 |   639.5 ns |  3.93 ns |  3.67 ns |  0.58 | 0.0458 |     - |     - |      96 B |
|                                |                      |       |            |          |          |       |        |       |       |           |
|                Linq_LinkedList |           LinkedList |   100 | 1,608.3 ns | 13.40 ns | 12.53 ns |  1.00 | 0.1221 |     - |     - |     256 B |
|           Hyperlinq_LinkedList |           LinkedList |   100 |   948.2 ns |  4.44 ns |  4.16 ns |  0.59 | 0.0458 |     - |     - |      96 B |
|                                |                      |       |            |          |          |       |        |       |       |           |
|                     Linq_Array |                Array |   100 |   685.2 ns |  5.54 ns |  4.91 ns |  1.00 | 0.0916 |     - |     - |     192 B |
|                Hyperlinq_Array |                Array |   100 |   570.9 ns |  2.96 ns |  2.76 ns |  0.83 | 0.0458 |     - |     - |      96 B |
|                 Hyperlinq_Span |                Array |   100 |   634.7 ns |  5.21 ns |  4.87 ns |  0.93 | 0.0458 |     - |     - |      96 B |
|               Hyperlinq_Memory |                Array |   100 |   586.3 ns |  2.90 ns |  2.71 ns |  0.86 | 0.0458 |     - |     - |      96 B |
|                                |                      |       |            |          |          |       |        |       |       |           |
|                      Linq_List |                 List |   100 |   908.6 ns |  5.85 ns |  5.47 ns |  1.00 | 0.1144 |     - |     - |     240 B |
|                 Hyperlinq_List |                 List |   100 |   536.0 ns |  5.88 ns |  4.91 ns |  0.59 | 0.0458 |     - |     - |      96 B |
|                StructLinq_List |                 List |   100 |   654.7 ns | 12.60 ns | 12.37 ns |  0.72 |      - |     - |     - |         - |
|                                |                      |       |            |          |          |       |        |       |       |           |
|      Linq_Enumerable_Reference | Enumerable_Reference |   100 | 1,168.2 ns |  3.66 ns |  3.24 ns |  1.00 | 0.1183 |     - |     - |     248 B |
| Hyperlinq_Enumerable_Reference | Enumerable_Reference |   100 | 1,137.3 ns |  7.42 ns |  6.94 ns |  0.97 | 0.0648 |     - |     - |     136 B |
|                                |                      |       |            |          |          |       |        |       |       |           |
|          Linq_Enumerable_Value |     Enumerable_Value |   100 | 1,307.9 ns | 10.78 ns |  9.00 ns |  1.00 | 0.1106 |     - |     - |     232 B |
|     Hyperlinq_Enumerable_Value |     Enumerable_Value |   100 |   574.5 ns |  4.24 ns |  3.97 ns |  0.44 | 0.0458 |     - |     - |      96 B |
