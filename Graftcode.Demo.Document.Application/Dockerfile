FROM mcr.microsoft.com/dotnet/sdk:10.0

WORKDIR /usr/app

COPY . /usr/app/

RUN dotnet build
RUN dotnet publish -c Release -o /usr/app/

RUN apt-get update \
&& apt-get install -y wget \
&& wget -O /usr/app/gg.deb https://github.com/grft-dev/graftcode-gateway/releases/latest/download/gg_linux_amd64.deb \
&& dpkg -i /usr/app/gg.deb \
&& rm /usr/app/gg.deb \
&& apt-get clean \
&& rm -rf /var/lib/apt/lists/*

EXPOSE 80
EXPOSE 81

CMD ["gg", "--modules", "Graftcode.Demo.Document.Application.dll", "--types", "Graftcode.Demo.Document.Application.DocumentServiceSurface"]