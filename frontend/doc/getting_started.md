# Getting started

## Adding a page

To add a page, generate a component by running `ng generate component *name*` from the plant-pod-companion directory. Make sure to give it a meaningful name that describes it's purpose. Don't use verbs in component names. Seperate words with dashes. Eg.: room-overview-page.

## Adding components to a page

Before building larger and more complex components with regular html syntax, check if any of the [angular material components](https://material.angular.io/components/categories) fit. you will have to do less styling and it will be easier.

## Styling

Use variables for the colors, these can be found in the global styles under frontend/plant-pod-companion/src/styles.scss. Only add styling to this file if it is relevant to more than one component.

Add styling for a component to the .scss style file of the component rather than to the html template (in-line). Add variables for values that are used multiple times. Use `rem` as units, these adapt to screen size.

## Resources

For starting out and basic tasks the [Angular Documentation](https://angular.io/docs) is a good place to look. For specific problems try to narrow it down and search google, there are many good answers on StackOverflow. If you still can't figure it out, please don't hesitate to ask :)

---
**NOTE**

If the frontend doesn't compile after a `git pull` try running `npm install`.

---
