using Mapster;

namespace ModelDto.General {
    public static class MapsterMap {
        public static Destination Map<Destination>(this object source) {
            if (source is null)
                throw new ArgumentNullException(nameof(source));
            return source.Adapt<Destination>();
        }
    }
}
