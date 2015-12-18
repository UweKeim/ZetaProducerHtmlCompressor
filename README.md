# Zeta Html Compressor

A .NET port of Google’s HtmlCompressor library to minify HTML source code.

[![Build state](https://travis-ci.org/UweKeim/ZetaProducerHtmlCompressor.svg?branch=master)](https://travis-ci.org/UweKeim/ZetaProducerHtmlCompressor "Travis CI build status")

## Introduction

This project is a port of [Google's Java HtmlCompressor library](https://code.google.com/p/htmlcompressor/) to remove extra whitespaces, comments and other unneeded characters without breaking the content structure.

## Usage

Simply include the [NuGet package](https://www.nuget.org/packages/ZetaProducerHtmlCompressor/) into your project.

See "[Minify HTML with inline CSS/JavaScript for MVC C# as a filter/attribute](https://gist.github.com/herman1vdb/a026e84330b481448b17)" as an example implementation (includes CSS and JavaScript minification using `System.Web.Optimization` bundling library).

## History

  * *2015-10-18* - First release to GitHub.
  * *2012-12-03* - First release. (Being used in our [CMS Zeta Producer](http://www.zeta-producer.com) ever since).
