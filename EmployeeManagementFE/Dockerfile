FROM node:lts-alpine

# install simple http server for serving static content
RUN npm install -g http-server

# make the 'app' folder the current working directory
WORKDIR /app
# copy 'package.json' (if available)
COPY package.json .
# install project dependencies
RUN npm install

# copy <source of app directory> <destination of container directory>
COPY . .

# build app for production with minification
RUN npm run build

# expose port by conector
EXPOSE 8080
CMD [ "http-server", "dist" ]