FROM microsoft/dotnet
EXPOSE 3001
ENV DB_URL 0.0.0.0:5000
COPY . /app
WORKDIR /app
RUN dotnet restore
CMD [ "dotnet", "run", "-p", "API" ]