/******/ (function(modules) { // webpackBootstrap
/******/ 	// The module cache
/******/ 	var installedModules = {};

/******/ 	// The require function
/******/ 	function __webpack_require__(moduleId) {

/******/ 		// Check if module is in cache
/******/ 		if(installedModules[moduleId])
/******/ 			return installedModules[moduleId].exports;

/******/ 		// Create a new module (and put it into the cache)
/******/ 		var module = installedModules[moduleId] = {
/******/ 			exports: {},
/******/ 			id: moduleId,
/******/ 			loaded: false
/******/ 		};

/******/ 		// Execute the module function
/******/ 		modules[moduleId].call(module.exports, module, module.exports, __webpack_require__);

/******/ 		// Flag the module as loaded
/******/ 		module.loaded = true;

/******/ 		// Return the exports of the module
/******/ 		return module.exports;
/******/ 	}


/******/ 	// expose the modules object (__webpack_modules__)
/******/ 	__webpack_require__.m = modules;

/******/ 	// expose the module cache
/******/ 	__webpack_require__.c = installedModules;

/******/ 	// __webpack_public_path__
/******/ 	__webpack_require__.p = "";

/******/ 	// Load entry module and return exports
/******/ 	return __webpack_require__(0);
/******/ })
/************************************************************************/
/******/ ([
/* 0 */
/***/ function(module, exports, __webpack_require__) {

	__webpack_require__(1);

/***/ },
/* 1 */
/***/ function(module, exports, __webpack_require__) {

	// style-loader: Adds some css to the DOM by adding a <style> tag

	// load the styles
	var content = __webpack_require__(2);
	if(typeof content === 'string') content = [[module.id, content, '']];
	// add the styles to the DOM
	var update = __webpack_require__(4)(content, {});
	if(content.locals) module.exports = content.locals;
	// Hot Module Replacement
	if(false) {
		// When the styles change, update the <style> tags
		if(!content.locals) {
			module.hot.accept("!!./../node_modules/css-loader/index.js!./../node_modules/sass-loader/index.js!./main.scss", function() {
				var newContent = require("!!./../node_modules/css-loader/index.js!./../node_modules/sass-loader/index.js!./main.scss");
				if(typeof newContent === 'string') newContent = [[module.id, newContent, '']];
				update(newContent);
			});
		}
		// When the module is disposed, remove the <style> tags
		module.hot.dispose(function() { update(); });
	}

/***/ },
/* 2 */
/***/ function(module, exports, __webpack_require__) {

	exports = module.exports = __webpack_require__(3)();
	// imports


	// module
	exports.push([module.id, "body {\n  font-family: 'Roboto', sans-serif;\n  padding: 0;\n  margin: 0;\n  background-color: #f4f5f7;\n  position: relative;\n  min-height: 100%; }\n\nh1 {\n  border-bottom: #2c3137 solid 1px;\n  line-height: 100px;\n  text-align: center;\n  margin: 0; }\n\n.leftCol {\n  position: absolute;\n  top: 0;\n  left: -240px;\n  width: 240px;\n  background-color: #1e2329;\n  color: #bcbcbc;\n  font-size: 20px;\n  min-height: 100%;\n  transition: left 0.2s ease-in; }\n\n.projectList {\n  padding: 0;\n  margin: 40px 20px;\n  list-style: none; }\n  .projectList > li {\n    padding: 23px 0;\n    border-bottom: #2c3137 solid 1px; }\n  .projectList > li.active > a {\n    color: #fff; }\n\n.sprintList {\n  padding: 0;\n  list-style: none; }\n  .sprintList > li {\n    margin: 20px 10px; }\n    .sprintList > li.active > a {\n      color: #fff; }\n    .sprintList > li:last-child {\n      margin-bottom: 0; }\n\n.leftCol a {\n  color: #bcbcbc;\n  text-decoration: none;\n  display: block; }\n  .leftCol a:hover {\n    color: #fff; }\n\n.projectList + .addButton {\n  margin: 20px;\n  display: block;\n  background: none;\n  border: #2c3137 solid 1px;\n  color: #bcbcbc;\n  font-size: 20px;\n  text-align: center;\n  padding: 16px; }\n  .projectList + .addButton:before {\n    content: '+';\n    margin-right: 10px; }\n\n.main {\n  margin-left: 0;\n  transition: margin-left 0.2s ease-in; }\n\n.main-header {\n  line-height: 100px;\n  font-size: 30px;\n  color: #90989b;\n  border-bottom: #bcbcbc solid 1px;\n  background-color: #fff; }\n  .main-header > span:first-child {\n    margin-left: 40px; }\n  .main-header > span:before {\n    content: '>';\n    margin: 0 10px; }\n  .main-header > span:first-child:before {\n    display: none; }\n\n.currentUser {\n  float: right;\n  margin-right: 40px;\n  font-size: 20px;\n  color: #1e2329; }\n  .currentUser-initials {\n    margin-left: 20px;\n    padding: 7px 15px;\n    background-color: #99c939;\n    color: #fff; }\n\n.main-content {\n  padding: 20px; }\n  .main-content > div {\n    flex-grow: 1; }\n\n.itemList {\n  margin: 20px;\n  background-color: #fff; }\n  .itemList-header {\n    height: 30px;\n    line-height: 30px;\n    background-color: #48c3ff;\n    color: #fff;\n    padding: 20px;\n    font-size: 20px; }\n  .itemList-header > h3 {\n    margin: 0; }\n  .itemList-content {\n    padding-top: 20px;\n    border-left: #eee solid 1px;\n    border-right: #eee solid 1px; }\n    .itemList-content.noFooter {\n      border-bottom: #eee solid 1px; }\n  .itemList-item {\n    margin: 20px;\n    padding-bottom: 10px;\n    border-bottom: #eee solid 1px;\n    overflow: hidden; }\n    .itemList-item:first-child {\n      margin-top: 0; }\n    .itemList-item:last-child {\n      border-bottom: none;\n      margin-bottom: 0; }\n    .itemList-item > a {\n      font-weight: lighter;\n      font-size: 20px;\n      color: #1e2329;\n      text-decoration: none;\n      display: block; }\n    .itemList-item-footer {\n      color: #d3dae2;\n      margin-top: 10px; }\n      .itemList-item-footer > span {\n        margin-right: 20px;\n        line-height: 30px;\n        height: 30px;\n        margin-bottom: 5px; }\n  .itemList-comments:before {\n    content: \"\\1F4AC\";\n    margin-right: 10px; }\n  .itemList-comments:hover:before {\n    color: #48c3ff; }\n  .itemList-attachments:before {\n    content: \"\\1F4CE\";\n    margin-right: 5px; }\n  .itemList-assignee {\n    float: right;\n    background: #ffbc2f;\n    padding: 0 5px;\n    color: #fff;\n    margin-right: 0; }\n\n.blackButton {\n  text-decoration: none;\n  display: block;\n  background: #1e2329;\n  color: #bcbcbc;\n  font-size: 20px;\n  text-align: center;\n  padding: 16px; }\n  .blackButton:before {\n    content: '+';\n    margin-right: 10px; }\n  .blackButton:hover {\n    color: #fff; }\n\n@media (min-width: 640px) {\n  .leftCol {\n    left: 0; }\n  .main {\n    margin-left: 240px; }\n  .itemList {\n    min-width: 300px; }\n  .main-content {\n    display: flex;\n    flex-wrap: wrap; } }\n", ""]);

	// exports


/***/ },
/* 3 */
/***/ function(module, exports) {

	/*
		MIT License http://www.opensource.org/licenses/mit-license.php
		Author Tobias Koppers @sokra
	*/
	// css base code, injected by the css-loader
	module.exports = function() {
		var list = [];

		// return the list of modules as css string
		list.toString = function toString() {
			var result = [];
			for(var i = 0; i < this.length; i++) {
				var item = this[i];
				if(item[2]) {
					result.push("@media " + item[2] + "{" + item[1] + "}");
				} else {
					result.push(item[1]);
				}
			}
			return result.join("");
		};

		// import a list of modules into the list
		list.i = function(modules, mediaQuery) {
			if(typeof modules === "string")
				modules = [[null, modules, ""]];
			var alreadyImportedModules = {};
			for(var i = 0; i < this.length; i++) {
				var id = this[i][0];
				if(typeof id === "number")
					alreadyImportedModules[id] = true;
			}
			for(i = 0; i < modules.length; i++) {
				var item = modules[i];
				// skip already imported module
				// this implementation is not 100% perfect for weird media query combinations
				//  when a module is imported multiple times with different media queries.
				//  I hope this will never occur (Hey this way we have smaller bundles)
				if(typeof item[0] !== "number" || !alreadyImportedModules[item[0]]) {
					if(mediaQuery && !item[2]) {
						item[2] = mediaQuery;
					} else if(mediaQuery) {
						item[2] = "(" + item[2] + ") and (" + mediaQuery + ")";
					}
					list.push(item);
				}
			}
		};
		return list;
	};


/***/ },
/* 4 */
/***/ function(module, exports, __webpack_require__) {

	/*
		MIT License http://www.opensource.org/licenses/mit-license.php
		Author Tobias Koppers @sokra
	*/
	var stylesInDom = {},
		memoize = function(fn) {
			var memo;
			return function () {
				if (typeof memo === "undefined") memo = fn.apply(this, arguments);
				return memo;
			};
		},
		isOldIE = memoize(function() {
			return /msie [6-9]\b/.test(window.navigator.userAgent.toLowerCase());
		}),
		getHeadElement = memoize(function () {
			return document.head || document.getElementsByTagName("head")[0];
		}),
		singletonElement = null,
		singletonCounter = 0;

	module.exports = function(list, options) {
		if(false) {
			if(typeof document !== "object") throw new Error("The style-loader cannot be used in a non-browser environment");
		}

		options = options || {};
		// Force single-tag solution on IE6-9, which has a hard limit on the # of <style>
		// tags it will allow on a page
		if (typeof options.singleton === "undefined") options.singleton = isOldIE();

		var styles = listToStyles(list);
		addStylesToDom(styles, options);

		return function update(newList) {
			var mayRemove = [];
			for(var i = 0; i < styles.length; i++) {
				var item = styles[i];
				var domStyle = stylesInDom[item.id];
				domStyle.refs--;
				mayRemove.push(domStyle);
			}
			if(newList) {
				var newStyles = listToStyles(newList);
				addStylesToDom(newStyles, options);
			}
			for(var i = 0; i < mayRemove.length; i++) {
				var domStyle = mayRemove[i];
				if(domStyle.refs === 0) {
					for(var j = 0; j < domStyle.parts.length; j++)
						domStyle.parts[j]();
					delete stylesInDom[domStyle.id];
				}
			}
		};
	}

	function addStylesToDom(styles, options) {
		for(var i = 0; i < styles.length; i++) {
			var item = styles[i];
			var domStyle = stylesInDom[item.id];
			if(domStyle) {
				domStyle.refs++;
				for(var j = 0; j < domStyle.parts.length; j++) {
					domStyle.parts[j](item.parts[j]);
				}
				for(; j < item.parts.length; j++) {
					domStyle.parts.push(addStyle(item.parts[j], options));
				}
			} else {
				var parts = [];
				for(var j = 0; j < item.parts.length; j++) {
					parts.push(addStyle(item.parts[j], options));
				}
				stylesInDom[item.id] = {id: item.id, refs: 1, parts: parts};
			}
		}
	}

	function listToStyles(list) {
		var styles = [];
		var newStyles = {};
		for(var i = 0; i < list.length; i++) {
			var item = list[i];
			var id = item[0];
			var css = item[1];
			var media = item[2];
			var sourceMap = item[3];
			var part = {css: css, media: media, sourceMap: sourceMap};
			if(!newStyles[id])
				styles.push(newStyles[id] = {id: id, parts: [part]});
			else
				newStyles[id].parts.push(part);
		}
		return styles;
	}

	function createStyleElement() {
		var styleElement = document.createElement("style");
		var head = getHeadElement();
		styleElement.type = "text/css";
		head.appendChild(styleElement);
		return styleElement;
	}

	function createLinkElement() {
		var linkElement = document.createElement("link");
		var head = getHeadElement();
		linkElement.rel = "stylesheet";
		head.appendChild(linkElement);
		return linkElement;
	}

	function addStyle(obj, options) {
		var styleElement, update, remove;

		if (options.singleton) {
			var styleIndex = singletonCounter++;
			styleElement = singletonElement || (singletonElement = createStyleElement());
			update = applyToSingletonTag.bind(null, styleElement, styleIndex, false);
			remove = applyToSingletonTag.bind(null, styleElement, styleIndex, true);
		} else if(obj.sourceMap &&
			typeof URL === "function" &&
			typeof URL.createObjectURL === "function" &&
			typeof URL.revokeObjectURL === "function" &&
			typeof Blob === "function" &&
			typeof btoa === "function") {
			styleElement = createLinkElement();
			update = updateLink.bind(null, styleElement);
			remove = function() {
				styleElement.parentNode.removeChild(styleElement);
				if(styleElement.href)
					URL.revokeObjectURL(styleElement.href);
			};
		} else {
			styleElement = createStyleElement();
			update = applyToTag.bind(null, styleElement);
			remove = function() {
				styleElement.parentNode.removeChild(styleElement);
			};
		}

		update(obj);

		return function updateStyle(newObj) {
			if(newObj) {
				if(newObj.css === obj.css && newObj.media === obj.media && newObj.sourceMap === obj.sourceMap)
					return;
				update(obj = newObj);
			} else {
				remove();
			}
		};
	}

	var replaceText = (function () {
		var textStore = [];

		return function (index, replacement) {
			textStore[index] = replacement;
			return textStore.filter(Boolean).join('\n');
		};
	})();

	function applyToSingletonTag(styleElement, index, remove, obj) {
		var css = remove ? "" : obj.css;

		if (styleElement.styleSheet) {
			styleElement.styleSheet.cssText = replaceText(index, css);
		} else {
			var cssNode = document.createTextNode(css);
			var childNodes = styleElement.childNodes;
			if (childNodes[index]) styleElement.removeChild(childNodes[index]);
			if (childNodes.length) {
				styleElement.insertBefore(cssNode, childNodes[index]);
			} else {
				styleElement.appendChild(cssNode);
			}
		}
	}

	function applyToTag(styleElement, obj) {
		var css = obj.css;
		var media = obj.media;
		var sourceMap = obj.sourceMap;

		if(media) {
			styleElement.setAttribute("media", media)
		}

		if(styleElement.styleSheet) {
			styleElement.styleSheet.cssText = css;
		} else {
			while(styleElement.firstChild) {
				styleElement.removeChild(styleElement.firstChild);
			}
			styleElement.appendChild(document.createTextNode(css));
		}
	}

	function updateLink(linkElement, obj) {
		var css = obj.css;
		var media = obj.media;
		var sourceMap = obj.sourceMap;

		if(sourceMap) {
			// http://stackoverflow.com/a/26603875
			css += "\n/*# sourceMappingURL=data:application/json;base64," + btoa(unescape(encodeURIComponent(JSON.stringify(sourceMap)))) + " */";
		}

		var blob = new Blob([css], { type: "text/css" });

		var oldSrc = linkElement.href;

		linkElement.href = URL.createObjectURL(blob);

		if(oldSrc)
			URL.revokeObjectURL(oldSrc);
	}


/***/ }
/******/ ]);