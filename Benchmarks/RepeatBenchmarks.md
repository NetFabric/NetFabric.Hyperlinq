## RepeatBenchmarks

### Source
[RepeatBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/RepeatBenchmarks.cs)

### References:
- Linq: 5.0.0-preview.6.20305.6
- System.Linq.Async: [4.1.1](https://www.nuget.org/packages/System.Linq.Async/4.1.1)
- System.Interactive: [4.1.1](https://www.nuget.org/packages/System.Interactive/4.1.1)
- System.Interactive.Async: [4.1.1](https://www.nuget.org/packages/System.Interactive.Async/4.1.1)
- StructLinq: [0.19.3](https://www.nuget.org/packages/StructLinq/0.19.3)
- NetFabric.Hyperlinq: [3.0.0-beta26](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta26)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=macOS Catalina 10.15.6 (19G2021) [Darwin 19.6.0]
Intel Core i5-7360U CPU 2.30GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.100-preview.6.20318.15
  [Host]        : .NET Core 5.0.0 (CoreCLR 5.0.20.30506, CoreFX 5.0.20.30506), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.0 (CoreCLR 5.0.20.30506, CoreFX 5.0.20.30506), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|                 Method |   Categories | Count |        Mean |      Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|----------------------- |------------- |------ |------------:|-----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|            Linq_Repeat |       Repeat |   100 |   561.98 ns |   7.870 ns |  6.572 ns |     ? |       ? | 0.0191 |     - |     - |      40 B |
|                        |              |       |             |            |           |       |         |        |       |       |           |
|      Linq_Repeat_Count | Repeat_Count |   100 |   544.10 ns |  10.929 ns | 11.694 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      32 B |
| Hyperlinq_Repeat_Count | Repeat_Count |   100 |    45.25 ns |   0.948 ns |  0.792 ns |  0.08 |    0.00 |      - |     - |     - |         - |
|                        |              |       |             |            |           |       |         |        |       |       |           |
|      Linq_Repeat_Async | Repeat_Async |   100 | 7,489.75 ns | 113.841 ns | 95.063 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      48 B |
| Hyperlinq_Repeat_Async | Repeat_Async |   100 | 1,073.86 ns |   7.156 ns |  6.344 ns |  0.14 |    0.00 |      - |     - |     - |         - |
