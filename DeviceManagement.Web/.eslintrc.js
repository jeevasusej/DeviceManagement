module.exports = {
  parser:  '@typescript-eslint/parser',  // Specifies the ESLint parser
  extends:  [
    'plugin:@typescript-eslint/recommended',  // Uses the recommended rules from the @typescript-eslint/eslint-plugin
    'prettier/@typescript-eslint',  // Uses eslint-config-prettier to disable ESLint rules from @typescript-eslint/eslint-plugin that would conflict with prettier
    'plugin:prettier/recommended',  // Enables eslint-plugin-prettier and displays prettier errors as ESLint errors. Make sure this is always the last configuration in the extends array.
    "airbnb-typescript",
  ],
  "parserOptions":  {
    "sourceType": "module",  // Allows for the use of imports
    "ecmaFeatures": {
      "jsx": true
    }
  },
  "rules": {
       /**
       * @description rules of eslint official
       */
      /**
       * @bug https://github.com/benmosher/eslint-plugin-import/issues/1282
       * "import/named" temporary disable.
       */
      "import/named": "off",
      /**
       * @bug?
       * "import/export" temporary disable.
       */
      "import/export": "off",
      "import/prefer-default-export": "off", // Allow single Named-export
      "no-unused-expressions": ["warn", {
        "allowShortCircuit": true,
        "allowTernary": true
      }], // https://eslint.org/docs/rules/no-unused-expressions

      /**
       * @description rules of @typescript-eslint
       */
      // "@typescript-eslint/prefer-interface": "off", // also want to use "type"
      "@typescript-eslint/explicit-function-return-type": "off", // annoying to force return type

      /**
       * @description rules of eslint-plugin-react
       */
      "react/jsx-filename-extension": ["warn", {
        "extensions": [".jsx", ".tsx"]
      }], // also want to use with ".tsx"
      "react/prop-types": "off", // Is this incompatible with TS props type?
      "arrow-body-style": ["error", "as-needed", { "requireReturnForObjectLiteral": true }],
       "@typescript-eslint/no-empty-interface": [
          "error", {
            "allowSingleExtends": true
          }
        ],
         "linebreak-style": 0
  },
  "env": {
      "browser": true,
      "node": true
  },
  "settings": {
    "react": {
      "version": "detect"
    }
  }
}
