# Stage 1: Build Angular app
FROM node:18 AS build
WORKDIR /app

# Install dependencies
COPY BMSF/package*.json ./
RUN npm install

# Copy the rest of the frontend source
COPY BMSF/. .

# Build Angular app for production
RUN npm run build --prod

# Stage 2: Serve app with nginx
FROM nginx:alpine

# Copy built Angular app into Nginx's root
COPY --from=build /app/dist/bmsf/browser /usr/share/nginx/html


