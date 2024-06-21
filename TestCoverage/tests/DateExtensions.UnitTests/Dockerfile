# Use the official .NET SDK image to build the app and run tests
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# Set the working directory
WORKDIR /app

# Copy the project files to the working directory
COPY . .

# Restore the project dependencies
RUN dotnet restore

# Run tests and collect code coverage
RUN dotnet test --collect:"XPlat Code Coverage" --results-directory ./testresults


# Install reportgenerator tool
RUN dotnet tool install -g dotnet-reportgenerator-globaltool

# Add the tool to the PATH
ENV PATH="${PATH}:/root/.dotnet/tools"

# Generate the HTML report
RUN reportgenerator -reports:"./testresults/*/coverage.cobertura.xml" -targetdir:coverage_report -reporttypes:Html

# Use the official Nginx image to serve the report
FROM nginx:alpine

# Copy the generated HTML report from the build stage
COPY --from=build /app/coverage_report /usr/share/nginx/html

# Expose port 80
EXPOSE 80

# Start Nginx server
CMD ["nginx", "-g", "daemon off;"]
