# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [1.1.0](https://github.com/unity-game-framework/ugf-yaml/releases/tag/1.1.0) - 2020-12-21  

### Release Notes

- [Milestone](https://github.com/unity-game-framework/ugf-yaml/milestone/1?closed=1)  
    

### Added

- Change properties serialization order of inherited members ([#5](https://github.com/unity-game-framework/ugf-yaml/pull/5))  
    - Add `YamlPropertyInheritanceCountComparer` and `YamlPropertyInheritanceOrderTypeInspector ` used to sort serialized properties depending on inheritance.
    - Change `YamlUtility.CreateDefaultSerializerBuilder` to use `YamlPropertyInheritanceOrderTypeInspector` and sort properties by default.
- Add methods to create default serializer and deserializer ([#4](https://github.com/unity-game-framework/ugf-yaml/pull/4))  
    - Add `YamlUtility.CreateDefaultSerializerBuilder` and `CreateDefaultDeserializerBuilder` methods to create serializer and deserializer builder with default properties.
    - Add `DefaultSerializer` and `DefaultDeserializer` properties with default serializer and deserializer.

## [1.0.0](https://github.com/unity-game-framework/ugf-yaml/releases/tag/1.0.0) - 2020-10-08  

### Release Notes

- No release notes.


