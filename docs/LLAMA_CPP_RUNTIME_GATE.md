# Joni llama.cpp CUDA Runtime Gate

This gate installs and validates the first real AI inference runtime dependency for Joni without downloading an LLM model.

## Upstream

- Project: `ggml-org/llama.cpp`
- Stable release: `v0.3.0`
- Official binary build referenced by that release: `b10621`
- Target: Windows x64, NVIDIA CUDA 13.3

## Trust and installation chain

1. Fetch `manifests/llama-runtime-stable.json` over HTTPS.
2. Verify its detached RSA-3072 / SHA-256 signature before parsing JSON.
3. Apply anti-rollback sequence checks.
4. Select the compatible NVIDIA hardware profile.
5. Download only the hash-pinned official GitHub Release assets declared by the signed manifest.
6. Validate final redirect host, exact archive size and SHA-256.
7. Extract ZIP archives through a path-traversal-safe staging routine.
8. Require `llama-cli.exe` and `llama-server.exe`.
9. Run `llama-cli.exe --version`.
10. Run `llama-cli.exe --list-devices` and require CUDA plus `NVIDIA GeForce RTX 5080` for the current RTX 5080 gate profile.
11. Promote the staged runtime only after health checks pass.
12. Simulate a damaged runtime executable, require health failure, restore the known-good copy and require CUDA health again.
13. Commit manifest sequence 4 only after the entire gate succeeds.

## Current scope

Passing this gate proves that the real llama.cpp runtime is installed and can enumerate the NVIDIA CUDA device. It does not install an LLM model and does not yet provide Joni prompt responses.
