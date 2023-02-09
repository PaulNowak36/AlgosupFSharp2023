Pacman
======

Build Pacman for the browser using F# and Fable.

To setup the first time you need to do three things:
1. Install Fable
2. Install Node.js & NPM
3. Restore the Node.js dependencies

## Installing Fable

To install Fable you will need to run the following command:

```
dotnet tool restore
```
## Installing Node.js & NPM

You'll need to install Node.js and NPM for your operating system
(you may already have them installed). The install the web dependencies:


## Restore the Node.js dependencies

Once node is installed to restore the dependencies use this command:

```
npm install
```

## Running Pacman

Each time you want to build and run Pacman use:

```
dotnet fable src --run webpack serve
```

This will compile the F# code to Javascript and launch the webpack
web-server. You can see the resulting app by browsing to:
http://localhost:8080