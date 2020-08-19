## CastBenchmarks

### References:
- StructLinq.BCL: [0.19.1](https://www.nuget.org/packages/StructLinq.BCL/0.19.1)
- NetFabric.Hyperlinq: [3.0.0-beta25](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta25)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.100-preview.7.20366.6
  [Host]     : .NET Core 5.0.0 (CoreCLR 5.0.20.36411, CoreFX 5.0.20.36411), X64 RyuJIT
  DefaultJob : .NET Core 5.0.0 (CoreCLR 5.0.20.36411, CoreFX 5.0.20.36411), X64 RyuJIT


```
|                    Method |      Mean |     Error |    StdDev |    Median | Ratio | RatioSD | Gen 0 | Gen 1 | Gen 2 | Allocated |
|-------------------------- |----------:|----------:|----------:|----------:|------:|--------:|------:|------:|------:|----------:|
|    EnumerableIsEnumerable | 0.0001 ns | 0.0004 ns | 0.0004 ns | 0.0000 ns |     ? |       ? |     - |     - |     - |         - |
|  EnumerableIsReadOnlyList | 3.7806 ns | 0.0414 ns | 0.0367 ns | 3.7781 ns |     ? |       ? |     - |     - |     - |         - |
| EnumerableIsReadOnlyList2 | 9.5042 ns | 0.0738 ns | 0.0654 ns | 9.4779 ns |     ? |       ? |     - |     - |     - |         - |
|          EnumerableIsList | 3.3186 ns | 0.0185 ns | 0.0174 ns | 3.3184 ns |     ? |       ? |     - |     - |     - |         - |
|          ListIsEnumerable | 0.0000 ns | 0.0001 ns | 0.0001 ns | 0.0000 ns |     ? |       ? |     - |     - |     - |         - |
|        ListIsReadOnlyList | 0.0003 ns | 0.0014 ns | 0.0013 ns | 0.0000 ns |     ? |       ? |     - |     - |     - |         - |
|                ListIsList | 1.5768 ns | 0.0314 ns | 0.0294 ns | 1.5693 ns |     ? |       ? |     - |     - |     - |         - |
