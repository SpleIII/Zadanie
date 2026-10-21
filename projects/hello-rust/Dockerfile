FROM rust:1-slim AS builder
WORKDIR /build

COPY Cargo.toml ./

RUN mkdir src && echo "fn main() {}" > src/main.rs
RUN cargo build --release
RUN rm -f target/release/hello-rust target/release/deps/hello_rust-*

COPY src ./src

RUN cargo build --release

FROM debian:stable-slim

RUN useradd --create-home appuser
WORKDIR /home/appuser

COPY --from=builder /build/target/release/hello-rust ./hello-rust
USER appuser

ENTRYPOINT ["./hello-rust"]
